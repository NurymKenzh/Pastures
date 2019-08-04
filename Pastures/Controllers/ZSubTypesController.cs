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
    public class ZSubTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: ZSubTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var zsubtypes = db.ZSubTypes
                .Where(z => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                zsubtypes = zsubtypes.Where(z => z.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                zsubtypes = zsubtypes.Where(z => z.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    zsubtypes = zsubtypes.OrderBy(z => z.Code);
                    break;
                case "CodeDesc":
                    zsubtypes = zsubtypes.OrderByDescending(z => z.Code);
                    break;
                case "Description":
                    zsubtypes = zsubtypes.OrderBy(z => z.Description);
                    break;
                case "DescriptionDesc":
                    zsubtypes = zsubtypes.OrderByDescending(z => z.Description);
                    break;
                default:
                    zsubtypes = zsubtypes.OrderBy(z => z.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(zsubtypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: ZSubTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZSubType zSubType = await db.ZSubTypes.FindAsync(id);
            if (zSubType == null)
            {
                return HttpNotFound();
            }
            return View(zSubType);
        }

        // GET: ZSubTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] ZSubType zSubType)
        {
            if (ModelState.IsValid)
            {
                db.ZSubTypes.Add(zSubType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(zSubType);
        }

        // GET: ZSubTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZSubType zSubType = await db.ZSubTypes.FindAsync(id);
            if (zSubType == null)
            {
                return HttpNotFound();
            }
            return View(zSubType);
        }

        // POST: ZSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] ZSubType zSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zSubType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zSubType);
        }

        // GET: ZSubTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZSubType zSubType = await db.ZSubTypes.FindAsync(id);
            if (zSubType == null)
            {
                return HttpNotFound();
            }
            return View(zSubType);
        }

        // POST: ZSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ZSubType zSubType = await db.ZSubTypes.FindAsync(id);
            db.ZSubTypes.Remove(zSubType);
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
