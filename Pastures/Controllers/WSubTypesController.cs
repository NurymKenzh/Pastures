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
    public class WSubTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: WSubTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var wsubtypes = db.WSubTypes
                .Where(w => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                wsubtypes = wsubtypes.Where(w => w.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                wsubtypes = wsubtypes.Where(w => w.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    wsubtypes = wsubtypes.OrderBy(w => w.Code);
                    break;
                case "CodeDesc":
                    wsubtypes = wsubtypes.OrderByDescending(w => w.Code);
                    break;
                case "Description":
                    wsubtypes = wsubtypes.OrderBy(w => w.Description);
                    break;
                case "DescriptionDesc":
                    wsubtypes = wsubtypes.OrderByDescending(w => w.Description);
                    break;
                default:
                    wsubtypes = wsubtypes.OrderBy(w => w.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(wsubtypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: WSubTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WSubType wSubType = await db.WSubTypes.FindAsync(id);
            if (wSubType == null)
            {
                return HttpNotFound();
            }
            return View(wSubType);
        }

        // GET: WSubTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] WSubType wSubType)
        {
            if (ModelState.IsValid)
            {
                db.WSubTypes.Add(wSubType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wSubType);
        }

        // GET: WSubTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WSubType wSubType = await db.WSubTypes.FindAsync(id);
            if (wSubType == null)
            {
                return HttpNotFound();
            }
            return View(wSubType);
        }

        // POST: WSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] WSubType wSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wSubType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wSubType);
        }

        // GET: WSubTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WSubType wSubType = await db.WSubTypes.FindAsync(id);
            if (wSubType == null)
            {
                return HttpNotFound();
            }
            return View(wSubType);
        }

        // POST: WSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WSubType wSubType = await db.WSubTypes.FindAsync(id);
            db.WSubTypes.Remove(wSubType);
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
