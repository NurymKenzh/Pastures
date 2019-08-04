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
    public class DominantTypesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: DominantTypes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, int? Code, string Description, int? Page)
        {
            var dominanttypes = db.DominantTypes
                .Where(d => true);

            ViewBag.CodeFilter = Code;
            ViewBag.DescriptionFilter = Description;

            ViewBag.CodeSort = SortOrder == "Code" ? "CodeDesc" : "Code";
            ViewBag.DescriptionSort = SortOrder == "Description" ? "DescriptionDesc" : "Description";

            if (Code != null)
            {
                dominanttypes = dominanttypes.Where(d => d.Code == Code);
            }
            if (!string.IsNullOrEmpty(Description))
            {
                dominanttypes = dominanttypes.Where(d => d.Description.Contains(Description));
            }

            switch (SortOrder)
            {
                case "Code":
                    dominanttypes = dominanttypes.OrderBy(d => d.Code);
                    break;
                case "CodeDesc":
                    dominanttypes = dominanttypes.OrderByDescending(d => d.Code);
                    break;
                case "Description":
                    dominanttypes = dominanttypes.OrderBy(d => d.Description);
                    break;
                case "DescriptionDesc":
                    dominanttypes = dominanttypes.OrderByDescending(d => d.Description);
                    break;
                default:
                    dominanttypes = dominanttypes.OrderBy(d => d.Id);
                    break;
            }

            int PageSize = 50;
            int PageNumber = (Page ?? 1);

            return View(dominanttypes.ToPagedList(PageNumber, PageSize));
        }

        // GET: DominantTypes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DominantType dominantType = await db.DominantTypes.FindAsync(id);
            if (dominantType == null)
            {
                return HttpNotFound();
            }
            return View(dominantType);
        }

        // GET: DominantTypes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DominantTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Code,Description")] DominantType dominantType)
        {
            if (ModelState.IsValid)
            {
                db.DominantTypes.Add(dominantType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dominantType);
        }

        // GET: DominantTypes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DominantType dominantType = await db.DominantTypes.FindAsync(id);
            if (dominantType == null)
            {
                return HttpNotFound();
            }
            return View(dominantType);
        }

        // POST: DominantTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Description")] DominantType dominantType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dominantType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dominantType);
        }

        // GET: DominantTypes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DominantType dominantType = await db.DominantTypes.FindAsync(id);
            if (dominantType == null)
            {
                return HttpNotFound();
            }
            return View(dominantType);
        }

        // POST: DominantTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DominantType dominantType = await db.DominantTypes.FindAsync(id);
            db.DominantTypes.Remove(dominantType);
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
        //                    DominantType dtype = new DominantType()
        //                    {
        //                        Code = Convert.ToInt32(c[0]),
        //                        Description = c[1]
        //                    };
        //                    db.DominantTypes.Add(dtype);
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
