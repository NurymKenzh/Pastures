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
    public class ZTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: ZTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var ztypes = db.ZTypes
                .Where(z => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                ztypes = ztypes.Where(z => z.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                ztypes = ztypes.Where(z => z.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    ztypes = ztypes.OrderBy(z => z.Code);
                    break;
                case "CodeDesc":
                    ztypes = ztypes.OrderByDescending(z => z.Code);
                    break;
                case "Description":
                    ztypes = ztypes.OrderBy(z => z.Description);
                    break;
                case "DescriptionDesc":
                    ztypes = ztypes.OrderByDescending(z => z.Description);
                    break;
                default:
                    ztypes = ztypes.OrderBy(z => z.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(ztypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: ZTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZType zType = await db.ZTypes.FindAsync(id);
            if (zType == null)
            {
                return HttpNotFound();
            }
            return View(zType);
        }

        // GET: ZTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description,Color")] ZType zType)
        {
            if (ModelState.IsValid)
            {
                db.ZTypes.Add(zType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(zType);
        }

        // GET: ZTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZType zType = await db.ZTypes.FindAsync(id);
            if (zType == null)
            {
                return HttpNotFound();
            }
            return View(zType);
        }

        // POST: ZTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description,Color")] ZType zType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zType);
        }

        // GET: ZTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZType zType = await db.ZTypes.FindAsync(id);
            if (zType == null)
            {
                return HttpNotFound();
            }
            return View(zType);
        }

        // POST: ZTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ZType zType = await db.ZTypes.FindAsync(id);
            db.ZTypes.Remove(zType);
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
