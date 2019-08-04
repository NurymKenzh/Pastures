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
    public class BurSubOtdelsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: BurSubOtdels
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var bursubotdels = db.BurSubOtdels
                .Where(b => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                bursubotdels = bursubotdels.Where(b => b.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                bursubotdels = bursubotdels.Where(b => b.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    bursubotdels = bursubotdels.OrderBy(b => b.Code);
                    break;
                case "CodeDesc":
                    bursubotdels = bursubotdels.OrderByDescending(b => b.Code);
                    break;
                case "Description":
                    bursubotdels = bursubotdels.OrderBy(b => b.Description);
                    break;
                case "DescriptionDesc":
                    bursubotdels = bursubotdels.OrderByDescending(b => b.Description);
                    break;
                default:
                    bursubotdels = bursubotdels.OrderBy(b => b.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(bursubotdels.ToPagedList(PageNumber, PageSize));
        }

        // GET: BurSubOtdels/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurSubOtdel burSubOtdel = await db.BurSubOtdels.FindAsync(id);
            if (burSubOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burSubOtdel);
        }

        // GET: BurSubOtdels/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurSubOtdels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] BurSubOtdel burSubOtdel)
        {
            if (ModelState.IsValid)
            {
                db.BurSubOtdels.Add(burSubOtdel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(burSubOtdel);
        }

        // GET: BurSubOtdels/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurSubOtdel burSubOtdel = await db.BurSubOtdels.FindAsync(id);
            if (burSubOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burSubOtdel);
        }

        // POST: BurSubOtdels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] BurSubOtdel burSubOtdel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(burSubOtdel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(burSubOtdel);
        }

        // GET: BurSubOtdels/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurSubOtdel burSubOtdel = await db.BurSubOtdels.FindAsync(id);
            if (burSubOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burSubOtdel);
        }

        // POST: BurSubOtdels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BurSubOtdel burSubOtdel = await db.BurSubOtdels.FindAsync(id);
            db.BurSubOtdels.Remove(burSubOtdel);
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
