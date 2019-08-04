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
    public class BGroupsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: BGroups
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var bgroups = db.BGroups
                .Where(b => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                bgroups = bgroups.Where(b => b.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                bgroups = bgroups.Where(b => b.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    bgroups = bgroups.OrderBy(b => b.Code);
                    break;
                case "CodeDesc":
                    bgroups = bgroups.OrderByDescending(b => b.Code);
                    break;
                case "Description":
                    bgroups = bgroups.OrderBy(b => b.Description);
                    break;
                case "DescriptionDesc":
                    bgroups = bgroups.OrderByDescending(b => b.Description);
                    break;
                default:
                    bgroups = bgroups.OrderBy(b => b.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(bgroups.ToPagedList(PageNumber, PageSize));
        }

        // GET: BGroups/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BGroup bGroup = await db.BGroups.FindAsync(id);
            if (bGroup == null)
            {
                return HttpNotFound();
            }
            return View(bGroup);
        }

        // GET: BGroups/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] BGroup bGroup)
        {
            if (ModelState.IsValid)
            {
                db.BGroups.Add(bGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bGroup);
        }

        // GET: BGroups/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BGroup bGroup = await db.BGroups.FindAsync(id);
            if (bGroup == null)
            {
                return HttpNotFound();
            }
            return View(bGroup);
        }

        // POST: BGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] BGroup bGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bGroup);
        }

        // GET: BGroups/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BGroup bGroup = await db.BGroups.FindAsync(id);
            if (bGroup == null)
            {
                return HttpNotFound();
            }
            return View(bGroup);
        }

        // POST: BGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BGroup bGroup = await db.BGroups.FindAsync(id);
            db.BGroups.Remove(bGroup);
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
