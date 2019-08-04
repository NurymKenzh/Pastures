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
    public class ChemicalCompsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: ChemicalComps
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var chemicalcomps = db.ChemicalComps
                .Where(c => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                chemicalcomps = chemicalcomps.Where(c => c.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                chemicalcomps = chemicalcomps.Where(c => c.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    chemicalcomps = chemicalcomps.OrderBy(c => c.Code);
                    break;
                case "CodeDesc":
                    chemicalcomps = chemicalcomps.OrderByDescending(c => c.Code);
                    break;
                case "Description":
                    chemicalcomps = chemicalcomps.OrderBy(c => c.Description);
                    break;
                case "DescriptionDesc":
                    chemicalcomps = chemicalcomps.OrderByDescending(c => c.Description);
                    break;
                default:
                    chemicalcomps = chemicalcomps.OrderBy(c => c.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(chemicalcomps.ToPagedList(PageNumber, PageSize));
        }

        // GET: ChemicalComps/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemicalComp chemicalComp = await db.ChemicalComps.FindAsync(id);
            if (chemicalComp == null)
            {
                return HttpNotFound();
            }
            return View(chemicalComp);
        }

        // GET: ChemicalComps/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChemicalComps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] ChemicalComp chemicalComp)
        {
            if (ModelState.IsValid)
            {
                db.ChemicalComps.Add(chemicalComp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chemicalComp);
        }

        // GET: ChemicalComps/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemicalComp chemicalComp = await db.ChemicalComps.FindAsync(id);
            if (chemicalComp == null)
            {
                return HttpNotFound();
            }
            return View(chemicalComp);
        }

        // POST: ChemicalComps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] ChemicalComp chemicalComp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemicalComp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chemicalComp);
        }

        // GET: ChemicalComps/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemicalComp chemicalComp = await db.ChemicalComps.FindAsync(id);
            if (chemicalComp == null)
            {
                return HttpNotFound();
            }
            return View(chemicalComp);
        }

        // POST: ChemicalComps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChemicalComp chemicalComp = await db.ChemicalComps.FindAsync(id);
            db.ChemicalComps.Remove(chemicalComp);
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
