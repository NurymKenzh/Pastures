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
    public class HorsesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Horses
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Breed, int? Page)
        {
            var horses = db.Horses
                .Where(h => true);

            ViewBag.CodeFilter = Code;
            ViewBag.BreedFilter = Breed;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.BreedSort = SortOrder == "Breed" ? "BreedDesc" : "Breed";

            if (Code != null)
            {
                horses = horses.Where(h => h.Code == Code);
            }
            if (!string.IsNullOrEmpty(Breed))
            {
                horses = horses.Where(h => h.Breed.Contains(Breed));
            }

            switch (SortOrder)
            {
                case "Code":
                    horses = horses.OrderBy(h => h.Code);
                    break;
                case "CodeDesc":
                    horses = horses.OrderByDescending(h => h.Code);
                    break;
                case "Breed":
                    horses = horses.OrderBy(h => h.Breed);
                    break;
                case "BreedDesc":
                    horses = horses.OrderByDescending(h => h.Breed);
                    break;
                default:
                    horses = horses.OrderBy(h => h.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(horses.ToPagedList(PageNumber, PageSize));
        }

        // GET: Horses/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = await db.Horses.FindAsync(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        // GET: Horses/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Breed,Direction,Weight,Height,MilkYield,BodyLength,Bust,Metacarpus,TotalGoals,Bred,Range,Description")] Horse horse, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    horse.Photo = target.ToArray();
                }
                db.Horses.Add(horse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(horse);
        }

        // GET: Horses/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = await db.Horses.FindAsync(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        // POST: Horses/Edit/5
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
            var horse = db.Horses.Find(Id);
            if (TryUpdateModel(horse, "", new string[] { "Code","Breed","Direction","Weight","Height","MilkYield","BodyLength","Bust", "Metacarpus", "TotalGoals","Bred","Range","Description" }))
            {
                if (Photo != null && Photo.ContentLength > 0)
                {
                    horse.Photo = null;
                    MemoryStream target = new MemoryStream();
                    Photo.InputStream.CopyTo(target);
                    horse.Photo = target.ToArray();
                }
                db.Entry(horse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horse);
        }

        // GET: Horses/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horse horse = await db.Horses.FindAsync(id);
            if (horse == null)
            {
                return HttpNotFound();
            }
            return View(horse);
        }

        // POST: Horses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Horse horse = await db.Horses.FindAsync(id);
            db.Horses.Remove(horse);
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
