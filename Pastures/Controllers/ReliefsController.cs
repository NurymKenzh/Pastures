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

namespace Pastures.Controllers
{
    public class ReliefsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Reliefs
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var reliefs = db.Reliefs
                .Where(r => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                reliefs = reliefs.Where(r => r.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                reliefs = reliefs.Where(r => r.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    reliefs = reliefs.OrderBy(r => r.Code);
                    break;
                case "CodeDesc":
                    reliefs = reliefs.OrderByDescending(r => r.Code);
                    break;
                case "Description":
                    reliefs = reliefs.OrderBy(r => r.Description);
                    break;
                case "DescriptionDesc":
                    reliefs = reliefs.OrderByDescending(r => r.Description);
                    break;
                default:
                    reliefs = reliefs.OrderBy(r => r.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(reliefs.ToPagedList(PageNumber, PageSize));
        }

        // GET: Reliefs/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relief relief = await db.Reliefs.FindAsync(id);
            if (relief == null)
            {
                return HttpNotFound();
            }
            return View(relief);
        }

        // GET: Reliefs/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reliefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] Relief relief)
        {
            if (ModelState.IsValid)
            {
                db.Reliefs.Add(relief);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(relief);
        }

        // GET: Reliefs/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relief relief = await db.Reliefs.FindAsync(id);
            if (relief == null)
            {
                return HttpNotFound();
            }
            return View(relief);
        }

        // POST: Reliefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] Relief relief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relief).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(relief);
        }

        // GET: Reliefs/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relief relief = await db.Reliefs.FindAsync(id);
            if (relief == null)
            {
                return HttpNotFound();
            }
            return View(relief);
        }

        // POST: Reliefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Relief relief = await db.Reliefs.FindAsync(id);
            db.Reliefs.Remove(relief);
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
