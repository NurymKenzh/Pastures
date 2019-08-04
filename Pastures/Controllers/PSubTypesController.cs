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
    public class PSubTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: PSubTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var psubtypes = db.PSubTypes
                .Where(p => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                psubtypes = psubtypes.Where(p => p.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                psubtypes = psubtypes.Where(p => p.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    psubtypes = psubtypes.OrderBy(p => p.Code);
                    break;
                case "CodeDesc":
                    psubtypes = psubtypes.OrderByDescending(p => p.Code);
                    break;
                case "Description":
                    psubtypes = psubtypes.OrderBy(p => p.Description);
                    break;
                case "DescriptionDesc":
                    psubtypes = psubtypes.OrderByDescending(p => p.Description);
                    break;
                default:
                    psubtypes = psubtypes.OrderBy(p => p.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(psubtypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: PSubTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubType pSubType = await db.PSubTypes.FindAsync(id);
            if (pSubType == null)
            {
                return HttpNotFound();
            }
            return View(pSubType);
        }

        // GET: PSubTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] PSubType pSubType)
        {
            if (ModelState.IsValid)
            {
                db.PSubTypes.Add(pSubType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pSubType);
        }

        // GET: PSubTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubType pSubType = await db.PSubTypes.FindAsync(id);
            if (pSubType == null)
            {
                return HttpNotFound();
            }
            return View(pSubType);
        }

        // POST: PSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] PSubType pSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSubType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pSubType);
        }

        // GET: PSubTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSubType pSubType = await db.PSubTypes.FindAsync(id);
            if (pSubType == null)
            {
                return HttpNotFound();
            }
            return View(pSubType);
        }

        // POST: PSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSubType pSubType = await db.PSubTypes.FindAsync(id);
            db.PSubTypes.Remove(pSubType);
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
