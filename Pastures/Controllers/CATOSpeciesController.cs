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
using System.IO;
using System.Text;

namespace Pastures.Controllers
{
    public class CATOSpeciesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: CATOSpecies
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string CATOTE, int? Page)
        {
            var catospecies = db.CATOSpecies
                .Where(c => true);

            ViewBag.CodeFilter = Code;
            ViewBag.CATOTEFilter = CATOTE;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.CATOTESort = SortOrder == "CATOTE" ? "CATOTEDesc" : "CATOTE";

            if (Code != null)
            {
                catospecies = catospecies.Where(c => c.Code == Code);
            }
            if (!string.IsNullOrEmpty(CATOTE))
            {
                catospecies = catospecies.Where(c => c.CATOTE.Contains(CATOTE));
            }

            switch (SortOrder)
            {
                case "Code":
                    catospecies = catospecies.OrderBy(c => c.Code);
                    break;
                case "CodeDesc":
                    catospecies = catospecies.OrderByDescending(c => c.Code);
                    break;
                case "CATOTE":
                    catospecies = catospecies.OrderBy(c => c.CATOTE);
                    break;
                case "CATOTEDesc":
                    catospecies = catospecies.OrderByDescending(c => c.CATOTE);
                    break;
                default:
                    catospecies = catospecies.OrderBy(c => c.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(catospecies.ToPagedList(PageNumber, PageSize));
        }

        // GET: CATOSpecies/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOSpecies cATOSpecies = await db.CATOSpecies.FindAsync(id);
            if (cATOSpecies == null)
            {
                return HttpNotFound();
            }
            return View(cATOSpecies);
        }

        // GET: CATOSpecies/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATOSpecies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,CATOTE,Code")] CATOSpecies cATOSpecies)
        {
            if (ModelState.IsValid)
            {
                db.CATOSpecies.Add(cATOSpecies);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cATOSpecies);
        }

        // GET: CATOSpecies/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOSpecies cATOSpecies = await db.CATOSpecies.FindAsync(id);
            if (cATOSpecies == null)
            {
                return HttpNotFound();
            }
            return View(cATOSpecies);
        }

        // POST: CATOSpecies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CATOTE,Code")] CATOSpecies cATOSpecies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATOSpecies).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cATOSpecies);
        }

        // GET: CATOSpecies/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATOSpecies cATOSpecies = await db.CATOSpecies.FindAsync(id);
            if (cATOSpecies == null)
            {
                return HttpNotFound();
            }
            return View(cATOSpecies);
        }

        // POST: CATOSpecies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CATOSpecies cATOSpecies = await db.CATOSpecies.FindAsync(id);
            db.CATOSpecies.Remove(cATOSpecies);
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

        //[Authorize(Roles = "Admin, Moderator")]
        //public ActionResult Upload()
        //{
        //    return View();
        //}

        //[Authorize(Roles = "Admin, Moderator")]
        //[HttpPost]
        //public ActionResult Upload(IEnumerable<HttpPostedFileBase> Files)
        //{
        //    string report = "";
        //    DateTime start = DateTime.Now;
        //    db.Configuration.AutoDetectChangesEnabled = false;
        //    foreach (var file in Files)
        //    {
        //        report += "Файл\t" + file.FileName + ":<br/>";
        //        int count = 0;
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            BinaryReader b = new BinaryReader(file.InputStream);
        //            byte[] binData = b.ReadBytes((int)file.InputStream.Length);
        //            string result = Encoding.Default.GetString(binData);
        //            var strings = result.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //            foreach (string s in strings)
        //            {
        //                try
        //                {
        //                    var c = s.Split("\t".ToCharArray());
        //                    CATOSpecies catospecies = new CATOSpecies()
        //                    {
        //                        CATOTE = c[0],
        //                        Code = Convert.ToInt32(c[1])
        //                    };
        //                    db.CATOSpecies.Add(catospecies);
        //                    count++;
        //                }
        //                catch
        //                {
        //                    report += "строка\t\"" + s + "\" не распознана,<br/>";
        //                }
        //            }
        //        }
        //        db.SaveChanges();
        //        report += "загружено строк\t" + count.ToString() + ".<br/>";
        //    }
        //    TimeSpan time = DateTime.Now - start;
        //    report += time.ToString() + "<br/>";
        //    ViewBag.Report = report;
        //    return View();
        //}
    }
}
