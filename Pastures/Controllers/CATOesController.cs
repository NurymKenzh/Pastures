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
    public class CATOesController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        // GET: CATOes
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Index(string SortOrder, string AB, string CD, string EF, string HIJ, string Name, int? Page)
        {
            var catoes = db.CATOes
                .Where(c => true);

            ViewBag.ABFilter = AB;
            ViewBag.CDFilter = CD;
            ViewBag.EFFilter = EF;
            ViewBag.HIJFilter = HIJ;
            ViewBag.NameFilter = Name;

            ViewBag.NameSort = SortOrder == "Name" ? "NameDesc" : "Name";

            if (!string.IsNullOrEmpty(AB))
            {
                catoes = catoes.Where(c => c.AB.Contains(AB));
            }
            if (!string.IsNullOrEmpty(CD))
            {
                catoes = catoes.Where(c => c.CD.Contains(CD));
            }
            if (!string.IsNullOrEmpty(EF))
            {
                catoes = catoes.Where(c => c.EF.Contains(EF));
            }
            if (!string.IsNullOrEmpty(HIJ))
            {
                catoes = catoes.Where(c => c.HIJ.Contains(HIJ));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                catoes = catoes.Where(c => c.Name.Contains(Name));
            }

            switch (SortOrder)
            {
                case "Name":
                    catoes = catoes.OrderBy(c => c.Name);
                    break;
                case "NameDesc":
                    catoes = catoes.OrderByDescending(c => c.Name);
                    break;
                default:
                    catoes = catoes.OrderBy(c => c.Id);
                    break;
            }

            int PageSize = 100;
            int PageNumber = (Page ?? 1);

            return View(catoes.ToPagedList(PageNumber, PageSize));
        }

        // GET: CATOes/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATO cATO = await db.CATOes.FindAsync(id);
            if (cATO == null)
            {
                return HttpNotFound();
            }
            return View(cATO);
        }

        // GET: CATOes/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Create([Bind(Include = "Id,AB,CD,EF,HIJ,K,Name,NameKZ")] CATO cATO)
        {
            if (ModelState.IsValid)
            {
                db.CATOes.Add(cATO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cATO);
        }

        // GET: CATOes/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATO cATO = await db.CATOes.FindAsync(id);
            if (cATO == null)
            {
                return HttpNotFound();
            }
            return View(cATO);
        }

        // POST: CATOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AB,CD,EF,HIJ,K,Name,NameKZ")] CATO cATO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cATO);
        }

        // GET: CATOes/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATO cATO = await db.CATOes.FindAsync(id);
            if (cATO == null)
            {
                return HttpNotFound();
            }
            return View(cATO);
        }

        // POST: CATOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CATO cATO = await db.CATOes.FindAsync(id);
            db.CATOes.Remove(cATO);
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
        //    //db.Configuration.AutoDetectChangesEnabled = false;
        //    //foreach (var file in Files)
        //    //{
        //    //    report += "Файл\t" + file.FileName + ":<br/>";
        //    //    int count = 0;
        //    //    if (file != null && file.ContentLength > 0)
        //    //    {
        //    //        BinaryReader b = new BinaryReader(file.InputStream);
        //    //        byte[] binData = b.ReadBytes((int)file.InputStream.Length);
        //    //        string result = Encoding.Unicode.GetString(binData);
        //    //        var strings = result.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //    //        foreach (string s in strings)
        //    //        {
        //    //            try
        //    //            {
        //    //                var c = s.Split("\t".ToCharArray());
        //    //                CATO cato = new CATO()
        //    //                {
        //    //                    AB = c[0],
        //    //                    CD = c[1],
        //    //                    EF = c[2],
        //    //                    HIJ = c[3],
        //    //                    K = c[4],
        //    //                    NameKZ = c[5],
        //    //                    Name = c[6]
        //    //                };
        //    //                db.CATOes.Add(cato);
        //    //                count++;
        //    //            }
        //    //            catch
        //    //            {
        //    //                report += "строка\t\"" + s + "\" не распознана,<br/>";
        //    //            }
        //    //        }
        //    //    }
        //    //    db.SaveChanges();
        //    //    report += "загружено строк\t" + count.ToString() + ".<br/>";
        //    //}

        //    db.Configuration.AutoDetectChangesEnabled = false;

        //    List<species3> sps3 = db.species3.ToList();

        //    foreach (var file in Files)
        //    {
        //        report += "Файл\t" + file.FileName + ":<br/>";
        //        int count = 0;
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            BinaryReader b = new BinaryReader(file.InputStream);
        //            byte[] binData = b.ReadBytes((int)file.InputStream.Length);
        //            string result = Encoding.Unicode.GetString(binData);
        //            var strings = result.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //            foreach (string s in strings)
        //            {
        //                try
        //                {
        //                    var c = s.Split("\t".ToCharArray());
        //                    //CATO cato = new CATO()
        //                    //{
        //                    //    AB = c[0],
        //                    //    CD = c[1],
        //                    //    EF = c[2],
        //                    //    HIJ = c[3],
        //                    //    K = c[4],
        //                    //    NameKZ = c[5],
        //                    //    Name = c[6]
        //                    //};
        //                    //db.CATOes.Add(cato);
        //                    //if(c[1]== "113241000")
        //                    //{
        //                    //    int g = 3;
        //                    //}

        //                    species3 sp3 = sps3
        //                        .FirstOrDefault(sp => sp.kato_te == c[1]);
        //                    if(sp3!=null)
        //                    {
        //                        sp3.totalgoals = (!string.IsNullOrEmpty(c[4])) ? (int?) Convert.ToInt32(c[4]) : null;
        //                        sp3.cattle = (!string.IsNullOrEmpty(c[5])) ? (int?)Convert.ToInt32(c[5]) : null;
        //                        sp3.horses = (!string.IsNullOrEmpty(c[6])) ? (int?)Convert.ToInt32(c[6]) : null;
        //                        sp3.smallcattle = (!string.IsNullOrEmpty(c[7])) ? (int?)Convert.ToInt32(c[7]) : null;
        //                        sp3.camels = (!string.IsNullOrEmpty(c[9])) ? (int?)Convert.ToInt32(c[9]) : null;
        //                        sp3.conditional = (!string.IsNullOrEmpty(c[10])) ? (int?)Convert.ToDecimal(c[10]) : null;
        //                        //sp3.date = c[5];
        //                        sp3.source = (!string.IsNullOrEmpty(c[12])) ? (int?)Convert.ToInt32(c[12]) : null;
        //                        //sp3.population = Convert.ToInt32(c[5]);
        //                        //sp3.pastures = Convert.ToInt32(c[5]);
        //                        db.Entry(sp3).State = EntityState.Modified;
        //                    }
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

        //    //foreach(species1 species1 in db.species1)
        //    //{
        //    //    if((species1.date != "")||(species1.date != null))
        //    //    {
        //    //        species1.date = "2014 г.";
        //    //        db.Entry(species1).State = EntityState.Modified;
        //    //    }
        //    //}
        //    //foreach (species2 species2 in db.species2)
        //    //{
        //    //    if ((species2.date != "") || (species2.date != null))
        //    //    {
        //    //        species2.date = "2014 г.";
        //    //        db.Entry(species2).State = EntityState.Modified;
        //    //    }
        //    //}
        //    //foreach (species3 species3 in db.species3)
        //    //{
        //    //    if ((species3.date != "") || (species3.date != null))
        //    //    {
        //    //        species3.date = "2014 г.";
        //    //        db.Entry(species3).State = EntityState.Modified;
        //    //    }
        //    //}
        //    //db.SaveChanges();

        //    TimeSpan time = DateTime.Now - start;
        //    report += time.ToString() + "<br/>";
        //    ViewBag.Report = report;
        //    return View();
        //}
    }
}
