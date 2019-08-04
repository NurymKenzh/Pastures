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
using System.Text;

namespace Pastures.Controllers
{
    public class SoobsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Soobs
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var soobs = db.Soobs
                .Where(s => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                soobs = soobs.Where(s => s.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                soobs = soobs.Where(s => s.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    soobs = soobs.OrderBy(s => s.Code);
                    break;
                case "CodeDesc":
                    soobs = soobs.OrderByDescending(s => s.Code);
                    break;
                case "Description":
                    soobs = soobs.OrderBy(s => s.Description);
                    break;
                case "DescriptionDesc":
                    soobs = soobs.OrderByDescending(s => s.Description);
                    break;
                default:
                    soobs = soobs.OrderBy(s => s.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(soobs.ToPagedList(PageNumber, PageSize));
        }

        // GET: Soobs/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soob soob = await db.Soobs.FindAsync(id);
            if (soob == null)
            {
                return HttpNotFound();
            }
            return View(soob);
        }

        // GET: Soobs/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description,DescriptionLat")] Soob soob)
        {
            if (ModelState.IsValid)
            {
                db.Soobs.Add(soob);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(soob);
        }

        // GET: Soobs/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soob soob = await db.Soobs.FindAsync(id);
            if (soob == null)
            {
                return HttpNotFound();
            }
            return View(soob);
        }

        // POST: Soobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description,DescriptionLat")] Soob soob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soob).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(soob);
        }

        // GET: Soobs/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soob soob = await db.Soobs.FindAsync(id);
            if (soob == null)
            {
                return HttpNotFound();
            }
            return View(soob);
        }

        // POST: Soobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Soob soob = await db.Soobs.FindAsync(id);
            db.Soobs.Remove(soob);
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
