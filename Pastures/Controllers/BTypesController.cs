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
    public class BTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: BTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var btypes = db.BTypes
                .Where(b => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                btypes = btypes.Where(b => b.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                btypes = btypes.Where(b => b.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    btypes = btypes.OrderBy(b => b.Code);
                    break;
                case "CodeDesc":
                    btypes = btypes.OrderByDescending(b => b.Code);
                    break;
                case "Description":
                    btypes = btypes.OrderBy(b => b.Description);
                    break;
                case "DescriptionDesc":
                    btypes = btypes.OrderByDescending(b => b.Description);
                    break;
                default:
                    btypes = btypes.OrderBy(b => b.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(btypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: BTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BType bType = await db.BTypes.FindAsync(id);
            if (bType == null)
            {
                return HttpNotFound();
            }
            return View(bType);
        }

        // GET: BTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] BType bType)
        {
            if (ModelState.IsValid)
            {
                db.BTypes.Add(bType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bType);
        }

        // GET: BTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BType bType = await db.BTypes.FindAsync(id);
            if (bType == null)
            {
                return HttpNotFound();
            }
            return View(bType);
        }

        // POST: BTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] BType bType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bType);
        }

        // GET: BTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BType bType = await db.BTypes.FindAsync(id);
            if (bType == null)
            {
                return HttpNotFound();
            }
            return View(bType);
        }

        // POST: BTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BType bType = await db.BTypes.FindAsync(id);
            db.BTypes.Remove(bType);
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
