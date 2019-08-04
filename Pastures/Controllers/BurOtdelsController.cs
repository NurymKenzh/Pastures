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
    public class BurOtdelsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: BurOtdels
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var burotdels = db.BurOtdels
                .Where(b => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                burotdels = burotdels.Where(b => b.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                burotdels = burotdels.Where(b => b.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    burotdels = burotdels.OrderBy(b => b.Code);
                    break;
                case "CodeDesc":
                    burotdels = burotdels.OrderByDescending(b => b.Code);
                    break;
                case "Description":
                    burotdels = burotdels.OrderBy(b => b.Description);
                    break;
                case "DescriptionDesc":
                    burotdels = burotdels.OrderByDescending(b => b.Description);
                    break;
                default:
                    burotdels = burotdels.OrderBy(b => b.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(burotdels.ToPagedList(PageNumber, PageSize));
        }

        // GET: BurOtdels/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurOtdel burOtdel = await db.BurOtdels.FindAsync(id);
            if (burOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burOtdel);
        }

        // GET: BurOtdels/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurOtdels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] BurOtdel burOtdel)
        {
            if (ModelState.IsValid)
            {
                db.BurOtdels.Add(burOtdel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(burOtdel);
        }

        // GET: BurOtdels/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurOtdel burOtdel = await db.BurOtdels.FindAsync(id);
            if (burOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burOtdel);
        }

        // POST: BurOtdels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] BurOtdel burOtdel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(burOtdel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(burOtdel);
        }

        // GET: BurOtdels/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BurOtdel burOtdel = await db.BurOtdels.FindAsync(id);
            if (burOtdel == null)
            {
                return HttpNotFound();
            }
            return View(burOtdel);
        }

        // POST: BurOtdels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BurOtdel burOtdel = await db.BurOtdels.FindAsync(id);
            db.BurOtdels.Remove(burOtdel);
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
