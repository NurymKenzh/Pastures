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
    public class SupplyRecommendsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: SupplyRecommends
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var supplyRecommends = db.SupplyRecommends
                .Where(r => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                supplyRecommends = supplyRecommends.Where(r => r.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                supplyRecommends = supplyRecommends.Where(r => r.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    supplyRecommends = supplyRecommends.OrderBy(r => r.Code);
                    break;
                case "CodeDesc":
                    supplyRecommends = supplyRecommends.OrderByDescending(r => r.Code);
                    break;
                case "Description":
                    supplyRecommends = supplyRecommends.OrderBy(r => r.Description);
                    break;
                case "DescriptionDesc":
                    supplyRecommends = supplyRecommends.OrderByDescending(r => r.Description);
                    break;
                default:
                    supplyRecommends = supplyRecommends.OrderBy(r => r.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(supplyRecommends.ToPagedList(PageNumber, PageSize));
        }

        // GET: SupplyRecommends/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyRecommend supplyRecommend = await db.SupplyRecommends.FindAsync(id);
            if (supplyRecommend == null)
            {
                return HttpNotFound();
            }
            return View(supplyRecommend);
        }

        // GET: SupplyRecommends/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyRecommends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] SupplyRecommend supplyRecommend)
        {
            if (ModelState.IsValid)
            {
                db.SupplyRecommends.Add(supplyRecommend);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(supplyRecommend);
        }

        // GET: SupplyRecommends/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyRecommend supplyRecommend = await db.SupplyRecommends.FindAsync(id);
            if (supplyRecommend == null)
            {
                return HttpNotFound();
            }
            return View(supplyRecommend);
        }

        // POST: SupplyRecommends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] SupplyRecommend supplyRecommend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplyRecommend).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(supplyRecommend);
        }

        // GET: SupplyRecommends/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplyRecommend supplyRecommend = await db.SupplyRecommends.FindAsync(id);
            if (supplyRecommend == null)
            {
                return HttpNotFound();
            }
            return View(supplyRecommend);
        }

        // POST: SupplyRecommends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SupplyRecommend supplyRecommend = await db.SupplyRecommends.FindAsync(id);
            db.SupplyRecommends.Remove(supplyRecommend);
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
