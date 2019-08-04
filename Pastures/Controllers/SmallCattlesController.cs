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
    public class SmallCattlesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: SmallCattles
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Breed, int? Page)
        {
            var smallcattles = db.SmallCattles
                .Where(s => true);

            ViewBag.CodeFilter = Code;
            ViewBag.BreedFilter = Breed;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.BreedSort = SortOrder == "Breed" ? "BreedDesc" : "Breed";

            if (Code != null)
            {
                smallcattles = smallcattles.Where(s => s.Code == Code);
            }
            if (!string.IsNullOrEmpty(Breed))
            {
                smallcattles = smallcattles.Where(s => s.Breed.Contains(Breed));
            }

            switch (SortOrder)
            {
                case "Code":
                    smallcattles = smallcattles.OrderBy(s => s.Code);
                    break;
                case "CodeDesc":
                    smallcattles = smallcattles.OrderByDescending(s => s.Code);
                    break;
                case "Breed":
                    smallcattles = smallcattles.OrderBy(s => s.Breed);
                    break;
                case "BreedDesc":
                    smallcattles = smallcattles.OrderByDescending(s => s.Breed);
                    break;
                default:
                    smallcattles = smallcattles.OrderBy(s => s.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(smallcattles.ToPagedList(PageNumber, PageSize));
        }

        // GET: SmallCattles/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmallCattle smallCattle = await db.SmallCattles.FindAsync(id);
            if (smallCattle == null)
            {
                return HttpNotFound();
            }
            return View(smallCattle);
        }

        // GET: SmallCattles/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmallCattles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Breed,Direction,Weight,Shearings,WashedWoolYield,Fertility,WoolLength,TotalGoals,Bred,Range,Description")] SmallCattle smallCattle, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    smallCattle.Photo = target.ToArray();
                }
                db.SmallCattles.Add(smallCattle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(smallCattle);
        }

        // GET: SmallCattles/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmallCattle smallCattle = await db.SmallCattles.FindAsync(id);
            if (smallCattle == null)
            {
                return HttpNotFound();
            }
            return View(smallCattle);
        }

        // POST: SmallCattles/Edit/5
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
            var smallcattle = db.SmallCattles.Find(Id);
            if (TryUpdateModel(smallcattle, "", new string[] { "Code","Breed","Direction","Weight","Shearings","WashedWoolYield","Fertility","WoolLength","TotalGoals","Bred","Range","Description" }))
            {
                if (Photo != null && Photo.ContentLength > 0)
                {
                    smallcattle.Photo = null;
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    smallcattle.Photo = target.ToArray();
                }
                db.Entry(smallcattle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smallcattle);
        }

        // GET: SmallCattles/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmallCattle smallCattle = await db.SmallCattles.FindAsync(id);
            if (smallCattle == null)
            {
                return HttpNotFound();
            }
            return View(smallCattle);
        }

        // POST: SmallCattles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SmallCattle smallCattle = await db.SmallCattles.FindAsync(id);
            db.SmallCattles.Remove(smallCattle);
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
