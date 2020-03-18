using Pastures.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastures.Controllers
{
    public class MapsController : Controller
    {
        private NpgsqlContext db = new NpgsqlContext();

        const string geoserverURL = "http://92.46.36.100:8080/geoserver/";

        struct PieData
        {
            public string label { get; set; }
            public decimal data { get; set; }
            public string color { get; set; }
            public string percent { get; set; }
        }

        struct CATOSpeciesShow
        {
            public string Type { get; set; }
            public string Breed { get; set; }
            public int Code { get; set; }
        }

        struct BreedShow
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        // GET: Maps
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FodderResources()
        {
            List<SelectListItem> MapSources = new List<SelectListItem>();
            var MapSourcesData = new[]{
                    new SelectListItem{ Value="OpenStreetMap",Text="Open Street Map", Selected = true},
                    new SelectListItem{ Value="ArcGIS",Text="ArcGIS"},
                    new SelectListItem{ Value="Bing",Text="Bing"},
                    new SelectListItem{ Value="BingAerial",Text="Bing Aerial"}
                    };
            MapSources = MapSourcesData.OrderBy(s => s.Text).ToList();
            ViewBag.MapSources = MapSources;

            ViewBag.PTypes = new SelectList(db.PTypes.ToList().OrderBy(p => p.Description), "Code", "Description");
            ViewBag.PSubTypes = new SelectList(db.PSubTypes.ToList().OrderBy(p => p.Description), "Code", "Description");
            ViewBag.Soobs = new SelectList(db.Soobs.ToList().OrderBy(s => s.Description), "Code", "Description");
            ViewBag.Otdels = new SelectList(db.Otdels.ToList().OrderBy(o => o.Description), "Code", "Description");
            ViewBag.Recommends = new SelectList(db.Recommends.ToList().OrderBy(r => r.Description), "Code", "Description");
            ViewBag.RecomCattles = new SelectList(db.RecomCattles.ToList().OrderBy(r => r.Description), "Code", "Description");

            ViewBag.CATOobl = new SelectList(db.CATOes
                .Where(c => (c.CD == "00"))
                .OrderBy(c => c.Name)
                ,
                    "TE",
                    "Name");

            ViewBag.geoserverURL = geoserverURL;

            return View();
        }

        public ActionResult LandSupply()
        {
            List<SelectListItem> MapSources = new List<SelectListItem>();
            var MapSourcesData = new[]{
                    new SelectListItem{ Value="OpenStreetMap",Text="Open Street Map", Selected = true},
                    new SelectListItem{ Value="ArcGIS",Text="ArcGIS"},
                    new SelectListItem{ Value="Bing",Text="Bing"},
                    new SelectListItem{ Value="BingAerial",Text="Bing Aerial"}
                    };
            MapSources = MapSourcesData.OrderBy(s => s.Text).ToList();
            ViewBag.MapSources = MapSources;

            ViewBag.STypes = new SelectList(db.STypes.ToList().OrderBy(z => z.Description), "Code", "Description");
            ViewBag.ZSubTypes = new SelectList(db.ZSubTypes.ToList().OrderBy(z => z.Description), "Code", "Description");
            ViewBag.DominantTypes = new SelectList(db.DominantTypes.ToList().OrderBy(d => d.Description), "Code", "Description");
            ViewBag.Recommends = new SelectList(db.Recommends.ToList().OrderBy(r => r.Description), "Code", "Description");

            ViewBag.CATOobl = new SelectList(db.CATOes
                .Where(c => (c.CD == "00"))
                .OrderBy(c => c.Name)
                ,
                    "TE",
                    "Name");

            ViewBag.geoserverURL = geoserverURL;

            return View();
        }

        public ActionResult Species()
        {
            List<SelectListItem> MapSources = new List<SelectListItem>();
            var MapSourcesData = new[]{
                    new SelectListItem{ Value="OpenStreetMap",Text="Open Street Map", Selected = true},
                    new SelectListItem{ Value="ArcGIS",Text="ArcGIS"},
                    new SelectListItem{ Value="Bing",Text="Bing"},
                    new SelectListItem{ Value="BingAerial",Text="Bing Aerial"}
                    };
            MapSources = MapSourcesData.OrderBy(s => s.Text).ToList();
            ViewBag.MapSources = MapSources;

            ViewBag.CATOobl = new SelectList(db.CATOes
                .Where(c => (c.CD == "00"))
                .OrderBy(c => c.Name)
                ,
                    "TE",
                    "Name");

            ViewBag.geoserverURL = geoserverURL;

            return View();
        }

        public ActionResult PasturesBurden()
        {
            List<SelectListItem> MapSources = new List<SelectListItem>();
            var MapSourcesData = new[]{
                    new SelectListItem{ Value="OpenStreetMap",Text="Open Street Map", Selected = true},
                    new SelectListItem{ Value="ArcGIS",Text="ArcGIS"},
                    new SelectListItem{ Value="Bing",Text="Bing"},
                    new SelectListItem{ Value="BingAerial",Text="Bing Aerial"}
                    };
            MapSources = MapSourcesData.OrderBy(s => s.Text).ToList();
            ViewBag.MapSources = MapSources;

            ViewBag.BurOtdels = new SelectList(db.BurOtdels.ToList().OrderBy(b => b.Description), "Code", "Description");
            ViewBag.BTypes = new SelectList(db.BTypes.ToList().OrderBy(b => b.Description), "Code", "Description");
            ViewBag.BurSubOtdels = new SelectList(db.BurSubOtdels.ToList().OrderBy(b => b.Description), "Code", "Description");
            ViewBag.BClasses = new SelectList(db.BClasses.ToList().OrderBy(b => b.Description), "Code", "Description");
            ViewBag.BGroups = new SelectList(db.BGroups.ToList().OrderBy(b => b.Description), "Code", "Description");

            ViewBag.CATOobl = new SelectList(db.CATOes
                .Where(c => (c.CD == "00"))
                .OrderBy(c => c.Name)
                ,
                    "TE",
                    "Name");

            ViewBag.geoserverURL = geoserverURL;

            return View();
        }

        public ActionResult Wells()
        {
            List<SelectListItem> MapSources = new List<SelectListItem>();
            var MapSourcesData = new[]{
                    new SelectListItem{ Value="OpenStreetMap",Text="Open Street Map", Selected = true},
                    new SelectListItem{ Value="ArcGIS",Text="ArcGIS"},
                    new SelectListItem{ Value="Bing",Text="Bing"},
                    new SelectListItem{ Value="BingAerial",Text="Bing Aerial"}
                    };
            MapSources = MapSourcesData.OrderBy(s => s.Text).ToList();
            ViewBag.MapSources = MapSources;

            ViewBag.WTypes = new SelectList(db.WTypes.ToList().OrderBy(w => w.Description), "Code", "Description");
            ViewBag.WSubTypes = new SelectList(db.WSubTypes.ToList().OrderBy(w => w.Description), "Code", "Description");
            ViewBag.ChemicalComps = new SelectList(db.ChemicalComps.ToList().OrderBy(c => c.Description), "Code", "Description");

            ViewBag.CATOobl = new SelectList(db.CATOes
                .Where(c => (c.CD == "00"))
                .OrderBy(c => c.Name)
                ,
                    "TE",
                    "Name");

            ViewBag.geoserverURL = geoserverURL;

            return View();
        }

        [HttpPost]
        public ActionResult GetCATORayons(string oblcatote)
        {
            string AB = oblcatote.Substring(0, 2);
            var catoes = db.CATOes
                .Where(c => c.AB == AB && c.CD != "00" && c.EF == "00")
                .ToList();
            catoes.Add(new CATO { Id = -1, Name = "" });
            var catoesn = catoes.OrderBy(c => c.Name).ToList();
            JsonResult rayons = new JsonResult();
            rayons.Data = catoesn;
            return rayons;
        }

        [HttpPost]
        public ActionResult GetCATOSOkrugs(string raycatote)
        {
            string AB = raycatote.Substring(0, 2);
            string CD = raycatote.Substring(2, 2);
            var catoes = db.CATOes
                .Where(c => c.AB == AB && c.CD == CD && c.EF != "00" && c.HIJ == "000")
                .ToList();
            catoes.Add(new CATO { Id = -1, Name = "" });
            var catoesn = catoes.OrderBy(c => c.Name).ToList();
            JsonResult sokrugs = new JsonResult();
            sokrugs.Data = catoesn;
            return sokrugs;
        }

        [HttpPost]
        public ActionResult GetPastureInfo(int objectid)
        {
            pasturepol pasturepol = db.pasturepol
                .Where(p => p.objectid == objectid)
                .FirstOrDefault();
            if (pasturepol == null)
            {
                return Json(new
                {
                    nomer_vydela = "",
                    class_id = "",
                    relief_id = "",
                    zone_id = "",
                    sybtype_id = "",
                    group_id = "",
                    otdel_id = "",
                    ur_v = "",
                    ur_l = "",
                    ur_o = "",
                    ur_z = "",
                    korm_v = "",
                    korm_l = "",
                    korm_o = "",
                    korm_z = "",
                    recommend_ = "",
                    recom_catt = ""
                });
            }
            PType ptype = null;
            if (pasturepol.class_id > 0)
            {
                ptype = db.PTypes
                    .Where(p => p.Code == pasturepol.class_id)
                    .FirstOrDefault();
            }
            Relief relief = null;
            if (pasturepol.relief_id > 0)
            {
                relief = db.Reliefs
                    .Where(r => r.Code == pasturepol.relief_id)
                    .FirstOrDefault();
            }
            Zone zone = null;
            if (pasturepol.zone_id > 0)
            {
                zone = db.Zones
                    .Where(z => z.Code == pasturepol.zone_id)
                    .FirstOrDefault();
            }
            PSubType psubtype = null;
            if (pasturepol.subtype_id > 0)
            {
                psubtype = db.PSubTypes
                    .Where(p => p.Code == pasturepol.subtype_id)
                    .FirstOrDefault();
            }
            Soob soob = null;
            if (pasturepol.group_id > 0)
            {
                soob = db.Soobs
                    .Where(s => s.Code == pasturepol.group_id)
                    .FirstOrDefault();
            }
            Otdel otdel = null;
            if (pasturepol.otdely_id > 0)
            {
                otdel = db.Otdels
                    .Where(o => o.Code == pasturepol.otdely_id)
                    .FirstOrDefault();
            }
            Recommend recommend = null;
            if (pasturepol.recommend_ > 0)
            {
                recommend = db.Recommends
                    .Where(r => r.Code == pasturepol.recommend_)
                    .FirstOrDefault();
            }
            RecomCattle recomcattle = null;
            if (pasturepol.recom_catt > 0)
            {
                recomcattle = db.RecomCattles
                    .Where(r => r.Code == pasturepol.recom_catt)
                    .FirstOrDefault();
            }

            return Json(new
            {
                nomer_vydela = pasturepol.group_id.ToString(),
                class_id = ptype != null ? ptype.Description : "",
                relief_id = relief != null ? relief.Description : "",
                zone_id = zone != null ? zone.Description : "",
                sybtype_id = psubtype != null ? psubtype.Description : "",
                group_id = soob != null ? soob.Description : "",
                group_id_lat = soob != null ? soob.DescriptionLat : "",
                otdel_id = otdel != null ? otdel.Description : "",
                ur_v = pasturepol.ur_v.ToString("0.0"),
                ur_l = pasturepol.ur_l.ToString("0.0"),
                ur_o = pasturepol.ur_o.ToString("0.0"),
                ur_z = pasturepol.ur_z.ToString("0.0"),
                korm_v = pasturepol.korm_v.ToString("0.0"),
                korm_l = pasturepol.korm_l.ToString("0.0"),
                korm_o = pasturepol.korm_o.ToString("0.0"),
                korm_z = pasturepol.korm_z.ToString("0.0"),
                recommend_ = recommend != null ? recommend.Description : "",
                recom_catt = recomcattle != null ? recomcattle.Description : ""
            });
        }

        [HttpPost]
        public ActionResult GetCATOPastureInfo(string catoobl, string catoray, string catosok)
        {
            List<PieData> otdels = new List<PieData>();
            List<PieData> classes = new List<PieData>();

            string name = " (все данные)";

            var pasturestat = db.pasturestat
                .Where(p => true)
                .ToList();
            // если есть область, район, сельский округ
            if ((catosok != "") && (catosok != null))
            {
                pasturestat = pasturestat
                    .Where(p => p.kato_te == catosok)
                    .ToList();
                name = " (" + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoobl)
                    .Select(c => c.Name)
                    .FirstOrDefault();
                name += ", " + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoray)
                    .Select(c => c.Name)
                    .FirstOrDefault();
                name += ", " + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catosok)
                    .Select(c => c.Name)
                    .FirstOrDefault() + ")";
            }
            // если есть только область, район
            if (((catoray != "") && (catoray != null)) && ((catosok == "") || (catosok == null)))
            {
                pasturestat = pasturestat
                    .Where(p => p.kato_te.Substring(0, 4) == catoray.Substring(0, 4))
                    .ToList();
                name = " (" + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoobl)
                    .Select(c => c.Name)
                    .FirstOrDefault();
                name += ", " + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoray)
                    .Select(c => c.Name)
                    .FirstOrDefault() + ")";
            }
            // если есть только область
            if (((catoobl != "") && (catoobl != null)) && ((catoray == "") || (catoray == null)) && ((catosok == "") || (catosok == null)))
            {
                pasturestat = pasturestat
                    .Where(p => p.kato_te.Substring(0, 2) == catoobl.Substring(0, 2))
                    .ToList();
                name = " (" + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoobl)
                    .Select(c => c.Name)
                    .FirstOrDefault() + ")";
            }
            
            foreach (Otdel otdel in db.Otdels.OrderBy(o => o.Description).ToList())
            {
                string label = otdel.Description;
                decimal data = pasturestat
                    .Where(p => p.otdely_id == otdel.Code)
                    .Select(p => (decimal)p.shape_area)
                    .Sum();
                if (data > 0)
                {
                    otdels.Add(new PieData()
                    {
                        label = label,
                        data = data
                    });
                }
            }
            decimal otdels_sum = otdels
                .Sum(o => o.data);
            for (int i = 0; i < otdels.Count; i++)
            {
                otdels[i] = new PieData()
                {
                    label = otdels[i].label + " (" + (otdels[i].data / otdels_sum * 100).ToString("F") + "%)",
                    data = otdels[i].data
                };
            }
            
            foreach (PType ptype in db.PTypes.OrderBy(p => p.Description).ToList())
            {
                string label = ptype.Description;
                decimal data = pasturestat
                    .Where(p => p.class_id == ptype.Code)
                    .Select(p => (decimal)p.shape_area)
                    .Sum();
                if (data > 0)
                {
                    classes.Add(new PieData()
                    {
                        label = label,
                        data = data
                    });
                }
            }
            decimal ptypes_sum = classes
                .Sum(o => o.data);
            for (int i = 0; i < classes.Count; i++)
            {
                classes[i] = new PieData()
                {
                    label = classes[i].label,
                    data = classes[i].data,
                    percent = (classes[i].data / ptypes_sum * 100).ToString("F") + "%"
                };
            }
            return Json(new
            {
                name = name,
                otdels = otdels,
                classes = classes
            });
        }

        [HttpPost]
        public ActionResult GetZZInfo(int objectid)
        {
            zemfondpol zemfondpol = db.zemfondpol
                .Where(z => z.objectid == objectid)
                .FirstOrDefault();
            if (zemfondpol == null)
            {
                return Json(new
                {
                    type_k = "",
                    ur_avgyear = "",
                    dominant_t = "",
                    korm_avgye = "",
                    area = "",
                    s_recomend = "",
                    subtype_k = ""
                });
            }
            SType stype = null;
            if (zemfondpol.type_k >= 0)
            {
                stype = db.STypes
                    .Where(z => z.Code == zemfondpol.type_k)
                    .FirstOrDefault();
            }
            DominantType dominanttype = null;
            if (zemfondpol.dominant_t >= 0)
            {
                dominanttype = db.DominantTypes
                    .Where(d => d.Code == zemfondpol.dominant_t)
                    .FirstOrDefault();
            }
            SupplyRecommend recommend = null;
            if (zemfondpol.s_recomend >= 0)
            {
                recommend = db.SupplyRecommends
                    .Where(r => r.Code == zemfondpol.s_recomend)
                    .FirstOrDefault();
            }
            ZSubType zsubtype = null;
            if (zemfondpol.subtype_k >= 0)
            {
                zsubtype = db.ZSubTypes
                    .Where(z => z.Code == zemfondpol.subtype_k)
                    .FirstOrDefault();
            }

            return Json(new
            {
                type_k = stype != null ? stype.Description : "",
                ur_avgyear = zemfondpol.ur_avgyear.ToString("F"),
                dominant_t = dominanttype != null ? dominanttype.Description : "",
                korm_avgye = zemfondpol.korm_avgye.ToString("F"),
                area = zemfondpol.area.ToString("0,0.00"),
                s_recomend = recommend != null ? recommend.Description : "",
                subtype_k = zsubtype != null ? zsubtype.Description : ""
            });
        }

        [HttpPost]
        public ActionResult GetCATOZZInfo(string catoobl, string catoray)
        {
            List<PieData> ztypes = new List<PieData>();
            List<PieData> zsubtypes = new List<PieData>();
            List<PieData> recommens = new List<PieData>();

            string name = " (все данные)";

            var zemfondpols = db.zemfondpol
                .Where(z => true)
                .ToList();
            if ((catoray != "")&&(catoray!=null))
            {
                zemfondpols = zemfondpols
                    .Where(z => z.kato_te_1 == catoray)
                    .ToList();
                name = " (" + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoobl)
                    .Select(c => c.Name)
                    .FirstOrDefault();
                name += ", " + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoray)
                    .Select(c => c.Name)
                    .FirstOrDefault() + ")";
            }
            if(((catoobl!="")&&(catoobl != null))&&((catoray=="")&&(catoray != null)))
            {
                zemfondpols = zemfondpols
                    .Where(z => z.kato_te_1.Substring(0, 2) == catoobl.Substring(0, 2))
                    .ToList();
                name = " (" + db.CATOes
                    .Where(c => c.AB + c.CD + c.EF + c.HIJ == catoobl)
                    .Select(c => c.Name)
                    .FirstOrDefault() + ")";
            }
            foreach (SType stype in db.STypes.OrderBy(z => z.Description).ToList())
            {
                string label = stype.Description;
                decimal data = zemfondpols
                    .Where(z => z.type_k == stype.Code)
                    .Select(z => (decimal)z.area)
                    .Sum();
                if (data > 0)
                {
                    ztypes.Add(new PieData()
                    {
                        label = label,
                        data = data
                    });
                }
            }
            decimal ztypes_sum = ztypes
                .Sum(z => z.data);
            for(int i=0;i<ztypes.Count;i++)
            {
                ztypes[i] = new PieData()
                {
                    label = ztypes[i].label + " (" + (ztypes[i].data / ztypes_sum * 100).ToString("F") + "%)",
                    data = ztypes[i].data,
                    color = ztypes[i].color
                };
            }
            foreach (ZSubType zsubtype in db.ZSubTypes.OrderBy(z => z.Description).ToList())
            {
                string label = zsubtype.Description;
                decimal data = zemfondpols
                    .Where(z => z.subtype_k == zsubtype.Code)
                    .Select(z => (decimal)z.area)
                    .Sum();
                if (data > 0)
                {
                    zsubtypes.Add(new PieData()
                    {
                        label = label,
                        data = data
                    });
                }
            }
            foreach (SupplyRecommend recommend in db.SupplyRecommends.OrderBy(r => r.Description).ToList())
            {
                string label = recommend.Description;
                decimal data = zemfondpols
                    .Where(z => z.s_recomend == recommend.Code)
                    .Select(z => (decimal)z.area)
                    .Sum();
                if (data > 0)
                {
                    recommens.Add(new PieData()
                    {
                        label = label,
                        data = data
                    });
                }
            }
            decimal recommens_sum = recommens
                .Sum(r => r.data);
            for (int i = 0; i < recommens.Count; i++)
            {
                recommens[i] = new PieData()
                {
                    label = recommens[i].label + " (" + (recommens[i].data / recommens_sum * 100).ToString("F") + "%)",
                    data = recommens[i].data
                };
            }
            decimal ur_avgyear = zemfondpols
                .Where(z => z.ur_avgyear > 0)
                .Select(z => z.ur_avgyear * z.area)
                .Sum();
            decimal area = zemfondpols
                .Where(z => z.ur_avgyear > 0)
                .Select(z => z.area)
                .Sum();
            if(area>0)
            {
                ur_avgyear = ur_avgyear / area;
            }
            else
            {
                ur_avgyear = 0;
            }
            decimal korm_avgye = zemfondpols
                .Select(z => z.korm_avgye)
                .Sum();
            return Json(new
            {
                name = name,
                ztypes = ztypes,
                zsubtypes = zsubtypes,
                recommens = recommens,
                ur_avgyear = ur_avgyear.ToString("F"),
                korm_avgye = korm_avgye.ToString("F")
            });
        }

        [HttpPost]
        public ActionResult GetCATOSpeciesInfo(int objectid, int type, bool? fromcato)
        {
            if (fromcato != null)
            {
                if (fromcato == true)
                {
                    string CATOTE = objectid.ToString();
                    if (type == 1)
                    {
                        objectid = db.species1
                            .Where(s => s.kato_te == CATOTE)
                            .FirstOrDefault()
                            .objectid;
                    }
                    if (type == 2)
                    {
                        objectid = db.species2
                            .Where(s => s.kato == CATOTE)
                            .FirstOrDefault()
                            .objectid;
                    }
                    if (type == 3)
                    {
                        objectid = db.species3
                            .Where(s => s.kato_te == CATOTE)
                            .FirstOrDefault()
                            .objectid;
                    }
                }
            }
            if (type == 1)
            {
                species1 species1 = db.species1
                    .Where(s => s.objectid == objectid)
                    .FirstOrDefault();
                if (species1 == null)
                {
                    return Json(new
                    {
                        CATO = "",
                        totalgoals = "",
                        cattle = "",
                        horses = "",
                        smallcattle = "",
                        camels = "",
                        conditional = "",
                        date = "",
                        type_k = "",
                        population = "",
                        pastures = ""
                    });
                }
                else
                {
                    CATO cato = db.CATOes
                        .Where(c => c.AB == species1.kato_te.Substring(0, 2) && c.CD == "00" && c.EF == "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    string CATO = "";
                    if (cato != null)
                    {
                        CATO = cato.Name;
                    }
                    var catospecies = db.CATOSpecies
                        .Where(c => c.CATOTE.Substring(0, 2) == species1.kato_te.Substring(0, 2))
                        .ToList();
                    List<CATOSpeciesShow> catospeciesshow = new List<CATOSpeciesShow>();
                    foreach (CATOSpecies cs in catospecies)
                    {
                        string Breed = "";
                        int Code = cs.Code;
                        string Type = "";
                        if (cs.Code > 400)
                        {
                            Type = "МРС";
                            Breed = db.SmallCattles
                                .Where(s => s.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 300)
                        {
                            Type = "Лошади";
                            Breed = db.Horses
                                .Where(h => h.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 200)
                        {
                            Type = "КРС";
                            Breed = db.Cattle
                                .Where(c => c.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 100)
                        {
                            Type = "Верблюды";
                            Breed = db.Camels
                                .Where(c => c.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        if(Breed!=null)
                        {
                            catospeciesshow.Add(new CATOSpeciesShow()
                            {
                                Code = Code,
                                Breed = Breed,
                                Type = Type
                            });
                        }
                    }
                    return Json(new
                    {
                        CATO = CATO,
                        totalgoals = species1.totalgoals.ToString(),
                        cattle = species1.cattle.ToString(),
                        horses = species1.horses.ToString(),
                        smallcattle = species1.smallcattle.ToString(),
                        camels = species1.camels.ToString(),
                        conditional = ((decimal)species1.conditional).ToString("F"),
                        date = species1.date != null ? species1.date : "",
                        catospecies = catospeciesshow.Distinct(),
                        type_k = "",
                        population = species1.population.ToString(),
                        pastures = species1.pastures.ToString(),
                    });
                }
            }
            else
            if (type == 2)
            {
                species2 species2 = db.species2
                    .Where(s => s.objectid == objectid)
                    .FirstOrDefault();
                if (species2 == null)
                {
                    return Json(new
                    {
                        CATO = "",
                        totalgoals = "",
                        cattle = "",
                        horses = "",
                        smallcattle = "",
                        camels = "",
                        conditional = "",
                        date = "",
                        type_k = "",
                        population = "",
                        pastures = ""
                    });
                }
                else
                {
                    CATO cato = db.CATOes
                        .Where(c => c.AB == species2.kato.Substring(0, 2) && c.CD == "00" && c.EF == "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    string CATO = "";
                    if (cato != null)
                    {
                        CATO = cato.Name;
                    }
                    CATO CATO_ray = db.CATOes
                        .Where(c => c.AB == species2.kato.Substring(0, 2) && c.CD == species2.kato.Substring(2, 2) && c.CD != "00" && c.EF == "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    if (CATO_ray != null)
                    {
                        CATO = CATO + ", " + CATO_ray.Name;
                    }
                    var catospecies = db.CATOSpecies
                        .Where(c => c.CATOTE == species2.kato)
                        .ToList();
                    List<CATOSpeciesShow> catospeciesshow = new List<CATOSpeciesShow>();
                    foreach (CATOSpecies cs in catospecies)
                    {
                        string Breed = "";
                        int Code = cs.Code;
                        string Type = "";
                        if (cs.Code > 400)
                        {
                            Type = "МРС";
                            Breed = db.SmallCattles
                                .Where(s => s.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 300)
                        {
                            Type = "Лошади";
                            Breed = db.Horses
                                .Where(h => h.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 200)
                        {
                            Type = "КРС";
                            Breed = db.Cattle
                                .Where(c => c.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        else
                        if (cs.Code > 100)
                        {
                            Type = "Верблюды";
                            Breed = db.Camels
                                .Where(c => c.Code == Code)
                                .FirstOrDefault()?
                                .Breed;
                        }
                        if(Breed!=null)
                        {
                            catospeciesshow.Add(new CATOSpeciesShow()
                            {
                                Code = Code,
                                Breed = Breed,
                                Type = Type
                            });
                        }
                    }
                    return Json(new
                    {
                        CATO = CATO,
                        totalgoals = species2.totalgoals.ToString(),
                        cattle = species2.cattle.ToString(),
                        horses = species2.horses.ToString(),
                        smallcattle = species2.smallcattle.ToString(),
                        camels = species2.camels.ToString(),
                        conditional = ((decimal)species2.conditional).ToString("F"),
                        date = species2.date != null ? species2.date : "",
                        catospecies = catospeciesshow,
                        type_k = "",
                        population = species2.population.ToString(),
                        pastures = species2.pastures.ToString(),
                    });
                }
            }
            else
            {
                species3 species3 = db.species3
                    .Where(s => s.objectid == objectid)
                    .FirstOrDefault();
                if (species3 == null)
                {
                    return Json(new
                    {
                        CATO = "",
                        totalgoals = "",
                        cattle = "",
                        horses = "",
                        smallcattle = "",
                        camels = "",
                        conditional = "",
                        date = "",
                        type_k = "",
                        population = "",
                        pastures = ""
                    });
                }
                else
                {
                    CATO cato = db.CATOes
                        .Where(c => c.AB == species3.kato_te.Substring(0, 2) && c.CD == "00" && c.EF == "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    string CATO = "";
                    if (cato != null)
                    {
                        CATO = cato.Name;
                    }
                    CATO CATO_ray = db.CATOes
                        .Where(c => c.AB == species3.kato_te.Substring(0, 2) && c.CD == species3.kato_te.Substring(2, 2) && c.CD != "00" && c.EF == "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    CATO CATO_sok = db.CATOes
                        .Where(c => c.AB == species3.kato_te.Substring(0, 2) && c.CD == species3.kato_te.Substring(2, 2) && c.CD != "00" && c.EF == species3.kato_te.Substring(4, 2) && c.EF != "00" && c.HIJ == "000")
                        .FirstOrDefault();
                    if (CATO_ray != null)
                    {
                        CATO = CATO + ", " + CATO_ray.Name;
                    }
                    if (CATO_sok != null)
                    {
                        CATO += ", " + CATO_sok.Name;
                    }
                    string type_k = db.ZTypes
                        .Where(z => z.Code == species3.type_k)
                        .FirstOrDefault()
                        .Description;
                    return Json(new
                    {
                        CATO = CATO,
                        totalgoals = species3.totalgoals.ToString(),
                        cattle = species3.cattle.ToString(),
                        horses = species3.horses.ToString(),
                        smallcattle = species3.smallcattle.ToString(),
                        camels = species3.camels.ToString(),
                        conditional = ((decimal)species3.conditional).ToString("F"),
                        date = species3.date != null ? species3.date : "",
                        type_k = type_k != null ? type_k : "",
                        population = species3.population.ToString(),
                        pastures = species3.pastures.ToString(),
                    });
                }
            }
        }

        [HttpPost]
        public ActionResult GetBreedInfo(int Code)
        {
            List<BreedShow> breed = new List<BreedShow>();
            if(Code>400)
            {
                SmallCattle sc = db.SmallCattles
                    .Where(s => s.Code == Code)
                    .FirstOrDefault();
                breed.Add(new BreedShow()
                {
                    Name = "Порода",
                    Value = sc.Breed != null ? sc.Breed: ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Направление",
                    Value = sc.Direction != null ? sc.Direction : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Живая масса",
                    Value = sc.Weight != null ? sc.Weight : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Настриг шерсти",
                    Value = sc.Shearings != null ? sc.Shearings : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Выход мытой шерсти",
                    Value = sc.WashedWoolYield != null ? sc.WashedWoolYield : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Плодовитость",
                    Value = sc.Fertility != null ? sc.Fertility : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Длина шерсти",
                    Value = sc.WoolLength != null ? sc.WoolLength : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Всего голов",
                    Value = sc.TotalGoals.ToString()
                });
                breed.Add(new BreedShow()
                {
                    Name = "Выведена",
                    Value = sc.Bred != null ? sc.Bred : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Ареал разведения",
                    Value = sc.Range != null ? sc.Range : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Примечание",
                    Value = sc.Description != null ? sc.Description : ""
                });
                return Json(new
                {
                    breedinfo = breed,
                    photo = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(sc.Photo))
                });
            }
            else if (Code > 300)
            {
                Horse horse = db.Horses
                    .Where(h => h.Code == Code)
                    .FirstOrDefault();
                breed.Add(new BreedShow()
                {
                    Name = "Порода",
                    Value = horse.Breed != null ? horse.Breed : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Направление",
                    Value = horse.Direction != null ? horse.Direction : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Живая масса жеребцов и кобыл",
                    Value = horse.Weight != null ? horse.Weight : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Высота в холке",
                    Value = horse.Height != null ? horse.Height : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Молочная продуктивность",
                    Value = horse.MilkYield != null ? horse.MilkYield : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Длина туловища",
                    Value = horse.BodyLength != null ? horse.BodyLength : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Обхват груди",
                    Value = horse.Bust != null ? horse.Bust : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Обхват пясти",
                    Value = horse.Metacarpus != null ? horse.Metacarpus : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Всего голов",
                    Value = horse.TotalGoals.ToString()
                });
                breed.Add(new BreedShow()
                {
                    Name = "Выведена",
                    Value = horse.Bred != null ? horse.Bred : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Ареал разведения",
                    Value = horse.Range != null ? horse.Range : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Примечание",
                    Value = horse.Description != null ? horse.Description : ""
                });
                return Json(new
                {
                    breedinfo = breed,
                    photo = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(horse.Photo))
                });
            }
            else if (Code > 200)
            {
                Cattle cattle = db.Cattle
                    .Where(c => c.Code == Code)
                    .FirstOrDefault();
                breed.Add(new BreedShow()
                {
                    Name = "Порода",
                    Value = cattle.Breed != null ? cattle.Breed : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Направление",
                    Value = cattle.Direction != null ? cattle.Direction : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Живая масса",
                    Value = cattle.Weight != null ? cattle.Weight : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Убойный выход",
                    Value = cattle.SlaughterYield != null ? cattle.SlaughterYield : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Удой маток",
                    Value = cattle.EwesYield != null ? cattle.EwesYield : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Всего голов",
                    Value = cattle.TotalGoals.ToString()
                });
                breed.Add(new BreedShow()
                {
                    Name = "Жирность молока",
                    Value = cattle.MilkFatContent != null ? cattle.MilkFatContent : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Выведена",
                    Value = cattle.Bred != null ? cattle.Bred : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Ареал разведения",
                    Value = cattle.Range != null ? cattle.Range : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Примечание",
                    Value = cattle.Description != null ? cattle.Description : ""
                });
                return Json(new
                {
                    breedinfo = breed,
                    photo = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(cattle.Photo))
                });
            }
            else if (Code > 100)
            {
                Camel camel = db.Camels
                    .Where(c => c.Code == Code)
                    .FirstOrDefault();
                breed.Add(new BreedShow()
                {
                    Name = "Порода",
                    Value = camel.Breed != null ? camel.Breed : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Живая масса",
                    Value = camel.Weight != null ? camel.Weight : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Убойный выход",
                    Value = camel.SlaughterYield.ToString("F")
                });
                breed.Add(new BreedShow()
                {
                    Name = "Удой маток",
                    Value = camel.EwesYield != null ? camel.EwesYield : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Всего голов",
                    Value = camel.TotalGoals.ToString()
                });
                breed.Add(new BreedShow()
                {
                    Name = "Жирность молока",
                    Value = camel.MilkFatContent != null ? camel.MilkFatContent : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Ареал разведения",
                    Value = camel.Range != null ? camel.Range : ""
                });
                breed.Add(new BreedShow()
                {
                    Name = "Примечание",
                    Value = camel.Description != null ? camel.Description : ""
                });
                return Json(new
                {
                    breedinfo = breed,
                    photo = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(camel.Photo))
                });
            }
            return Json(new
            {
                breedinfo = ""
            });
        }

        [HttpPost]
        public ActionResult GetPastureBurdenInfo(int objectid)
        {
            burden_pasture burden_pasture = db.burden_pasture
                .Where(b => b.objectid == objectid)
                .FirstOrDefault();
            if (burden_pasture == null)
            {
                return Json(new
                {
                    num_vydel = "",
                    rule_grazi = "",
                    bur_otdel = "",
                    bur_type_i = "",
                    bur_subotd = "",
                    bur_class_ = "",
                    bur_group_ = "",
                    average_yi = "",
                    burden_gro = "",
                    burden_deg = ""
                });
            }
            BurOtdel bur_otdel = null;
            if (burden_pasture.bur_otdel > 0)
            {
                bur_otdel = db.BurOtdels
                    .Where(b => b.Code == burden_pasture.bur_otdel)
                    .FirstOrDefault();
            }
            BType bur_type_i = null;
            if (burden_pasture.bur_type_i > 0)
            {
                bur_type_i = db.BTypes
                    .Where(b => b.Code == burden_pasture.bur_type_i)
                    .FirstOrDefault();
            }
            BurSubOtdel bur_subotd = null;
            if (burden_pasture.bur_subotd > 0)
            {
                bur_subotd = db.BurSubOtdels
                    .Where(b => b.Code == burden_pasture.bur_subotd)
                    .FirstOrDefault();
            }
            BClass bur_class_ = null;
            if (burden_pasture.bur_class_ > 0)
            {
                bur_class_ = db.BClasses
                    .Where(b => b.Code == burden_pasture.bur_class_)
                    .FirstOrDefault();
            }
            BGroup bur_group_ = null;
            if (burden_pasture.bur_group_ > 0)
            {
                bur_group_ = db.BGroups
                    .Where(b => b.Code == burden_pasture.bur_group_)
                    .FirstOrDefault();
            }

            return Json(new
            {
                num_vydel = burden_pasture.num_vydel.ToString(),
                rule_grazi = burden_pasture.rule_grazi.ToString(),
                bur_otdel = bur_otdel != null ? bur_otdel.Description : "",
                bur_type_i = bur_type_i != null ? bur_type_i.Description : "",
                bur_subotd = bur_subotd != null ? bur_subotd.Description : "",
                bur_class_ = bur_class_ != null ? bur_class_.Description : "",
                bur_group_ = bur_group_ != null ? bur_group_.Description : "",
                average_yi = burden_pasture.average_yi.ToString("F"),
                burden_gro = burden_pasture.burden_gro.ToString("F0"),
                burden_deg = burden_pasture.burden_deg.ToString("F0")
            });
        }

        [HttpPost]
        public ActionResult GetWellInfo(int objectid)
        {
            wellspnt wellspnt = db.wellspnt
                .Where(w => w.objectid == objectid)
                .FirstOrDefault();
            if (wellspnt == null)
            {
                return Json(new
                {
                    num = "",
                    usl = "",
                    wat_seepag = "",
                    debit = "",
                    decrease = "",
                    depth = "",
                    minerali = "",
                    chemical_c = ""
                });
            }
            WType wtype = null;
            if (wellspnt.usl >= 0)
            {
                wtype = db.WTypes
                    .Where(w => w.Code == wellspnt.usl)
                    .FirstOrDefault();
            }
            WSubType wsubtype = null;
            if (wellspnt.wat_seepag >= 0)
            {
                wsubtype = db.WSubTypes
                    .Where(w => w.Code == wellspnt.wat_seepag)
                    .FirstOrDefault();
            }
            ChemicalComp chemicalcomp = null;
            if (wellspnt.chemical_c >= 0)
            {
                chemicalcomp = db.ChemicalComps
                    .Where(c => c.Code == wellspnt.chemical_c)
                    .FirstOrDefault();
            }
            return Json(new
            {
                num = wellspnt.num != null ? wellspnt.num : "",
                usl = wtype != null ? wtype.Description : "",
                wat_seepag = wsubtype != null ? wsubtype.Description : "",
                debit = wellspnt.debit.ToString("F"),
                decrease = wellspnt.decrease.ToString("F"),
                depth = wellspnt.depth.ToString("F"),
                minerali = wellspnt.minerali.ToString("F"),
                chemical_c = chemicalcomp != null ? chemicalcomp.Description : ""
            });
        }

        [HttpPost]
        public ActionResult GetWellPolInfo(int objectid)
        {
            wellspol wellspol = db.wellspol
                .Where(w => w.objectid == objectid)
                .FirstOrDefault();
            if (wellspol == null)
            {
                return Json(new
                {
                    class_id = ""
                });
            }
            WClass wclass = null;
            if (wellspol.class_id > 0)
            {
                wclass = db.WClasses
                    .Where(w => w.Code == wellspol.class_id)
                    .FirstOrDefault();
            }
            return Json(new
            {
                class_id = wclass != null ? wclass.Description : ""
            });
        }
    }
}