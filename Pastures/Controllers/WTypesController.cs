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
    public class WTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: WTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var wtypes = db.WTypes
                .Where(w => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                wtypes = wtypes.Where(w => w.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                wtypes = wtypes.Where(w => w.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    wtypes = wtypes.OrderBy(w => w.Code);
                    break;
                case "CodeDesc":
                    wtypes = wtypes.OrderByDescending(w => w.Code);
                    break;
                case "Description":
                    wtypes = wtypes.OrderBy(w => w.Description);
                    break;
                case "DescriptionDesc":
                    wtypes = wtypes.OrderByDescending(w => w.Description);
                    break;
                default:
                    wtypes = wtypes.OrderBy(w => w.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(wtypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: WTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WType wType = await db.WTypes.FindAsync(id);
            if (wType == null)
            {
                return HttpNotFound();
            }
            return View(wType);
        }

        // GET: WTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] WType wType)
        {
            if (ModelState.IsValid)
            {
                db.WTypes.Add(wType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wType);
        }

        // GET: WTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WType wType = await db.WTypes.FindAsync(id);
            if (wType == null)
            {
                return HttpNotFound();
            }
            return View(wType);
        }

        // POST: WTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] WType wType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wType);
        }

        // GET: WTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WType wType = await db.WTypes.FindAsync(id);
            if (wType == null)
            {
                return HttpNotFound();
            }
            return View(wType);
        }

        // POST: WTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WType wType = await db.WTypes.FindAsync(id);
            db.WTypes.Remove(wType);
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
