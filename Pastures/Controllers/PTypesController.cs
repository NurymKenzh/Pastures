﻿using System;
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
    public class PTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: PTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var ptypes = db.PTypes
                .Where(p => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                ptypes = ptypes.Where(p => p.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                ptypes = ptypes.Where(p => p.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    ptypes = ptypes.OrderBy(p => p.Code);
                    break;
                case "CodeDesc":
                    ptypes = ptypes.OrderByDescending(p => p.Code);
                    break;
                case "Description":
                    ptypes = ptypes.OrderBy(p => p.Description);
                    break;
                case "DescriptionDesc":
                    ptypes = ptypes.OrderByDescending(p => p.Description);
                    break;
                default:
                    ptypes = ptypes.OrderBy(p => p.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(ptypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: PTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PType pType = await db.PTypes.FindAsync(id);
            if (pType == null)
            {
                return HttpNotFound();
            }
            return View(pType);
        }

        // GET: PTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] PType pType)
        {
            if (ModelState.IsValid)
            {
                db.PTypes.Add(pType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pType);
        }

        // GET: PTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PType pType = await db.PTypes.FindAsync(id);
            if (pType == null)
            {
                return HttpNotFound();
            }
            return View(pType);
        }

        // POST: PTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] PType pType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pType);
        }

        // GET: PTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PType pType = await db.PTypes.FindAsync(id);
            if (pType == null)
            {
                return HttpNotFound();
            }
            return View(pType);
        }

        // POST: PTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PType pType = await db.PTypes.FindAsync(id);
            db.PTypes.Remove(pType);
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
