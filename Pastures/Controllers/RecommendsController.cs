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
    public class RecommendsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: Recommends
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var recommends = db.Recommends
                .Where(r => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                recommends = recommends.Where(r => r.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                recommends = recommends.Where(r => r.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    recommends = recommends.OrderBy(r => r.Code);
                    break;
                case "CodeDesc":
                    recommends = recommends.OrderByDescending(r => r.Code);
                    break;
                case "Description":
                    recommends = recommends.OrderBy(r => r.Description);
                    break;
                case "DescriptionDesc":
                    recommends = recommends.OrderByDescending(r => r.Description);
                    break;
                default:
                    recommends = recommends.OrderBy(r => r.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(recommends.ToPagedList(PageNumber, PageSize));
        }

        // GET: Recommends/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = await db.Recommends.FindAsync(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // GET: Recommends/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recommends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] Recommend recommend)
        {
            if (ModelState.IsValid)
            {
                db.Recommends.Add(recommend);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recommend);
        }

        // GET: Recommends/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = await db.Recommends.FindAsync(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // POST: Recommends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] Recommend recommend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recommend).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recommend);
        }

        // GET: Recommends/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recommend recommend = await db.Recommends.FindAsync(id);
            if (recommend == null)
            {
                return HttpNotFound();
            }
            return View(recommend);
        }

        // POST: Recommends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recommend recommend = await db.Recommends.FindAsync(id);
            db.Recommends.Remove(recommend);
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
