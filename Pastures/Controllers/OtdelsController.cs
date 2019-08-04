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
    public class OtdelsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Otdels
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var otdels = db.Otdels
                .Where(o => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                otdels = otdels.Where(o => o.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                otdels = otdels.Where(o => o.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    otdels = otdels.OrderBy(o => o.Code);
                    break;
                case "CodeDesc":
                    otdels = otdels.OrderByDescending(o => o.Code);
                    break;
                case "Description":
                    otdels = otdels.OrderBy(o => o.Description);
                    break;
                case "DescriptionDesc":
                    otdels = otdels.OrderByDescending(o => o.Description);
                    break;
                default:
                    otdels = otdels.OrderBy(o => o.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(otdels.ToPagedList(PageNumber, PageSize));
        }

        // GET: Otdels/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otdel otdel = await db.Otdels.FindAsync(id);
            if (otdel == null)
            {
                return HttpNotFound();
            }
            return View(otdel);
        }

        // GET: Otdels/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Otdels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] Otdel otdel)
        {
            if (ModelState.IsValid)
            {
                db.Otdels.Add(otdel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(otdel);
        }

        // GET: Otdels/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otdel otdel = await db.Otdels.FindAsync(id);
            if (otdel == null)
            {
                return HttpNotFound();
            }
            return View(otdel);
        }

        // POST: Otdels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] Otdel otdel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otdel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(otdel);
        }

        // GET: Otdels/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otdel otdel = await db.Otdels.FindAsync(id);
            if (otdel == null)
            {
                return HttpNotFound();
            }
            return View(otdel);
        }

        // POST: Otdels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Otdel otdel = await db.Otdels.FindAsync(id);
            db.Otdels.Remove(otdel);
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
