using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pastures.Models;
using System.IO;
using System.Data.Entity.Infrastructure;
using PagedList;

namespace Pastures.Controllers
{
    public class CamelsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Camels
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Breed, int? Page)
        {
            var camels = db.Camels
                .Where(c => true);

            ViewBag.CodeFilter = Code;
            ViewBag.BreedFilter = Breed;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.BreedSort = SortOrder == "Breed" ? "BreedDesc" : "Breed";

            if (Code != null)
            {
                camels = camels.Where(c => c.Code == Code);
            }
            if (!string.IsNullOrEmpty(Breed))
            {
                camels = camels.Where(c => c.Breed.Contains(Breed));
            }

            switch (SortOrder)
            {
                case "Code":
                    camels = camels.OrderBy(c => c.Code);
                    break;
                case "CodeDesc":
                    camels = camels.OrderByDescending(c => c.Code);
                    break;
                case "Breed":
                    camels = camels.OrderBy(c => c.Breed);
                    break;
                case "BreedDesc":
                    camels = camels.OrderByDescending(c => c.Breed);
                    break;
                default:
                    camels = camels.OrderBy(c => c.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(camels.ToPagedList(PageNumber, PageSize));
        }

        // GET: Camels/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camel camel = await db.Camels.FindAsync(id);
            if (camel == null)
            {
                return HttpNotFound();
            }
            return View(camel);
        }

        // GET: Camels/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Breed,Weight,SlaughterYield,EwesYield,TotalGoals,MilkFatContent,Range,Description")] Camel camel, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if(Photo != null)
                {
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    camel.Photo = target.ToArray();
                }
                db.Camels.Add(camel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(camel);
        }

        // GET: Camels/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camel camel = await db.Camels.FindAsync(id);
            if (camel == null)
            {
                return HttpNotFound();
            }
            return View(camel);
        }

        // POST: Camels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? Id, HttpPostedFileBase Photo)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var camel = db.Camels.Find(Id);
            if (TryUpdateModel(camel, "", new string[] { "Code", "Breed", "Weight", "SlaughterYield", "EwesYield", "TotalGoals", "MilkFatContent", "Range", "Description" }))
            {
                if (Photo != null && Photo.ContentLength > 0)
                {
                    camel.Photo = null;
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    camel.Photo = target.ToArray();
                }
                db.Entry(camel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camel);
        }

        // GET: Camels/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camel camel = await db.Camels.FindAsync(id);
            if (camel == null)
            {
                return HttpNotFound();
            }
            return View(camel);
        }

        // POST: Camels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Camel camel = await db.Camels.FindAsync(id);
            db.Camels.Remove(camel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
