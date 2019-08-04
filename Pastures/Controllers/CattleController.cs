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
using PagedList;
using System.IO;

namespace Pastures.Controllers
{
    public class CattleController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Cattle
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Breed, int? Page)
        {
            var cattle = db.Cattle
                .Where(c => true);

            ViewBag.CodeFilter = Code;
            ViewBag.BreedFilter = Breed;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.BreedSort = SortOrder == "Breed" ? "BreedDesc" : "Breed";

            if (Code != null)
            {
                cattle = cattle.Where(c => c.Code == Code);
            }
            if (!string.IsNullOrEmpty(Breed))
            {
                cattle = cattle.Where(c => c.Breed.Contains(Breed));
            }

            switch (SortOrder)
            {
                case "Code":
                    cattle = cattle.OrderBy(c => c.Code);
                    break;
                case "CodeDesc":
                    cattle = cattle.OrderByDescending(c => c.Code);
                    break;
                case "Breed":
                    cattle = cattle.OrderBy(c => c.Breed);
                    break;
                case "BreedDesc":
                    cattle = cattle.OrderByDescending(c => c.Breed);
                    break;
                default:
                    cattle = cattle.OrderBy(c => c.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(cattle.ToPagedList(PageNumber, PageSize));
        }

        // GET: Cattle/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = await db.Cattle.FindAsync(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            return View(cattle);
        }

        // GET: Cattle/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cattle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Breed,Direction,Weight,SlaughterYield,EwesYield,TotalGoals,MilkFatContent,Bred,Range,Description")] Cattle cattle, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    cattle.Photo = target.ToArray();
                }
                db.Cattle.Add(cattle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cattle);
        }

        // GET: Cattle/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = await db.Cattle.FindAsync(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            return View(cattle);
        }

        // POST: Cattle/Edit/5
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
            var cattle = db.Cattle.Find(Id);
            if (TryUpdateModel(cattle, "", new string[] { "Code","Breed","Direction","Weight","SlaughterYield","EwesYield","TotalGoals","MilkFatContent","Bred","Range","Description" }))
            {
                if (Photo != null && Photo.ContentLength > 0)
                {
                    cattle.Photo = null;
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    cattle.Photo = target.ToArray();
                }
                db.Entry(cattle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cattle);
        }

        // GET: Cattle/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cattle cattle = await db.Cattle.FindAsync(id);
            if (cattle == null)
            {
                return HttpNotFound();
            }
            return View(cattle);
        }

        // POST: Cattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cattle cattle = await db.Cattle.FindAsync(id);
            db.Cattle.Remove(cattle);
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
