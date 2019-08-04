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
    public class RecomCattlesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: RecomCattles
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var recomcattles = db.RecomCattles
                .Where(r => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                recomcattles = recomcattles.Where(r => r.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                recomcattles = recomcattles.Where(r => r.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    recomcattles = recomcattles.OrderBy(r => r.Code);
                    break;
                case "CodeDesc":
                    recomcattles = recomcattles.OrderByDescending(r => r.Code);
                    break;
                case "Description":
                    recomcattles = recomcattles.OrderBy(r => r.Description);
                    break;
                case "DescriptionDesc":
                    recomcattles = recomcattles.OrderByDescending(r => r.Description);
                    break;
                default:
                    recomcattles = recomcattles.OrderBy(r => r.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(recomcattles.ToPagedList(PageNumber, PageSize));
        }

        // GET: RecomCattles/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecomCattle recomCattle = await db.RecomCattles.FindAsync(id);
            if (recomCattle == null)
            {
                return HttpNotFound();
            }
            return View(recomCattle);
        }

        // GET: RecomCattles/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecomCattles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] RecomCattle recomCattle)
        {
            if (ModelState.IsValid)
            {
                db.RecomCattles.Add(recomCattle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recomCattle);
        }

        // GET: RecomCattles/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecomCattle recomCattle = await db.RecomCattles.FindAsync(id);
            if (recomCattle == null)
            {
                return HttpNotFound();
            }
            return View(recomCattle);
        }

        // POST: RecomCattles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] RecomCattle recomCattle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recomCattle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recomCattle);
        }

        // GET: RecomCattles/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecomCattle recomCattle = await db.RecomCattles.FindAsync(id);
            if (recomCattle == null)
            {
                return HttpNotFound();
            }
            return View(recomCattle);
        }

        // POST: RecomCattles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RecomCattle recomCattle = await db.RecomCattles.FindAsync(id);
            db.RecomCattles.Remove(recomCattle);
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
