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
    public class WClassesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: WClasses
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var wclasses = db.WClasses
                .Where(w => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                wclasses = wclasses.Where(w => w.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                wclasses = wclasses.Where(w => w.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    wclasses = wclasses.OrderBy(w => w.Code);
                    break;
                case "CodeDesc":
                    wclasses = wclasses.OrderByDescending(w => w.Code);
                    break;
                case "Description":
                    wclasses = wclasses.OrderBy(w => w.Description);
                    break;
                case "DescriptionDesc":
                    wclasses = wclasses.OrderByDescending(w => w.Description);
                    break;
                default:
                    wclasses = wclasses.OrderBy(w => w.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(wclasses.ToPagedList(PageNumber, PageSize));
        }

        // GET: WClasses/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WClass wClass = await db.WClasses.FindAsync(id);
            if (wClass == null)
            {
                return HttpNotFound();
            }
            return View(wClass);
        }

        // GET: WClasses/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] WClass wClass)
        {
            if (ModelState.IsValid)
            {
                db.WClasses.Add(wClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wClass);
        }

        // GET: WClasses/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WClass wClass = await db.WClasses.FindAsync(id);
            if (wClass == null)
            {
                return HttpNotFound();
            }
            return View(wClass);
        }

        // POST: WClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] WClass wClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wClass);
        }

        // GET: WClasses/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WClass wClass = await db.WClasses.FindAsync(id);
            if (wClass == null)
            {
                return HttpNotFound();
            }
            return View(wClass);
        }

        // POST: WClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WClass wClass = await db.WClasses.FindAsync(id);
            db.WClasses.Remove(wClass);
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
