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
    public class STypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: STypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var stypes = db.STypes
                .Where(z => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                stypes = stypes.Where(z => z.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                stypes = stypes.Where(z => z.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    stypes = stypes.OrderBy(z => z.Code);
                    break;
                case "CodeDesc":
                    stypes = stypes.OrderByDescending(z => z.Code);
                    break;
                case "Description":
                    stypes = stypes.OrderBy(z => z.Description);
                    break;
                case "DescriptionDesc":
                    stypes = stypes.OrderByDescending(z => z.Description);
                    break;
                default:
                    stypes = stypes.OrderBy(z => z.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(stypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: STypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SType sType = await db.STypes.FindAsync(id);
            if (sType == null)
            {
                return HttpNotFound();
            }
            return View(sType);
        }

        // GET: STypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: STypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] SType sType)
        {
            if (ModelState.IsValid)
            {
                db.STypes.Add(sType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sType);
        }

        // GET: STypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SType sType = await db.STypes.FindAsync(id);
            if (sType == null)
            {
                return HttpNotFound();
            }
            return View(sType);
        }

        // POST: STypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] SType sType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sType);
        }

        // GET: STypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SType sType = await db.STypes.FindAsync(id);
            if (sType == null)
            {
                return HttpNotFound();
            }
            return View(sType);
        }

        // POST: STypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SType sType = await db.STypes.FindAsync(id);
            db.STypes.Remove(sType);
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
