using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    public class NpgsqlContext : DbContext
    {
        public NpgsqlContext() : base("name=NpgsqlContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pasturepol>().HasKey(p => p.gid);
            modelBuilder.Entity<pasturepol>().Property(p => p.ur_v).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.ur_l).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.ur_o).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.ur_z).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.korm_v).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.korm_l).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.korm_o).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.korm_z).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<pasturepol>().Property(p => p.shape_area).HasPrecision(29, 19);

            modelBuilder.Entity<zemfondpol>().HasKey(p => p.gid);
            modelBuilder.Entity<zemfondpol>().Property(z => z.ur_avgyear).HasPrecision(29, 19);
            modelBuilder.Entity<zemfondpol>().Property(z => z.korm_avgye).HasPrecision(29, 19);
            modelBuilder.Entity<zemfondpol>().Property(z => z.area).HasPrecision(29, 19);
            modelBuilder.Entity<zemfondpol>().Property(z => z.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<zemfondpol>().Property(z => z.shape_area).HasPrecision(29, 19);

            modelBuilder.Entity<Camel>().Property(c => c.SlaughterYield).HasPrecision(29, 19);

            modelBuilder.Entity<species1>().HasKey(p => p.gid);
            modelBuilder.Entity<species1>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<species1>().Property(p => p.shape_area).HasPrecision(29, 19);
            //modelBuilder.Entity<species1>().Property(p => p.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<species2>().HasKey(p => p.gid);
            modelBuilder.Entity<species2>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<species2>().Property(p => p.shape_area).HasPrecision(29, 19);
            //modelBuilder.Entity<species2>().Property(p => p.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<species3>().HasKey(p => p.gid);
            modelBuilder.Entity<species3>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<species3>().Property(p => p.shape_area).HasPrecision(29, 19);
            //modelBuilder.Entity<species3>().Property(p => p.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<wellspnt>().HasKey(w => w.gid);
            modelBuilder.Entity<wellspnt>().Property(w => w.debit).HasPrecision(29, 19);
            modelBuilder.Entity<wellspnt>().Property(w => w.decrease).HasPrecision(29, 19);
            modelBuilder.Entity<wellspnt>().Property(w => w.depth).HasPrecision(29, 19);
            modelBuilder.Entity<wellspnt>().Property(w => w.minerali).HasPrecision(29, 19);

            modelBuilder.Entity<burden_pasture>().HasKey(b => b.gid);
            modelBuilder.Entity<burden_pasture>().Property(b => b.average_yi).HasPrecision(29, 19);
            modelBuilder.Entity<burden_pasture>().Property(b => b.burden_gro).HasPrecision(29, 19);
            modelBuilder.Entity<burden_pasture>().Property(b => b.burden_deg).HasPrecision(29, 19);
            modelBuilder.Entity<burden_pasture>().Property(b => b.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<burden_pasture>().Property(b => b.shape_area).HasPrecision(29, 19);

            modelBuilder.Entity<species1>().Property(s => s.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<species2>().Property(s => s.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<species3>().Property(s => s.conditional).HasPrecision(29, 19);

            modelBuilder.Entity<wellspol>().HasKey(p => p.gid);
            modelBuilder.Entity<wellspol>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<wellspol>().Property(p => p.shape_area).HasPrecision(29, 19);

            modelBuilder.Entity<pasturestat>().HasKey(p => p.gid);
            modelBuilder.Entity<pasturestat>().Property(p => p.__gid).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.ur_v).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.ur_l).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.ur_o).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.ur_z).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.korm_v).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.korm_l).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.korm_o).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.korm_z).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.shape_leng).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.shape_area).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.objectid).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.class_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.relief_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.zone_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.subtype_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.group_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.recommend_).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.recom_catt).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.haying_id).HasPrecision(29, 19);
            modelBuilder.Entity<pasturestat>().Property(p => p.otdely_id).HasPrecision(29, 19);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Pastures.Models.CATO> CATOes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.PType> PTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Relief> Reliefs { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Zone> Zones { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.PSubType> PSubTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Soob> Soobs { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Recommend> Recommends { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.RecomCattle> RecomCattles { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.pasturepol> pasturepol { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Haying> Hayings { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Otdel> Otdels { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.ZType> ZTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.DominantType> DominantTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.ZSubType> ZSubTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.zemfondpol> zemfondpol { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Camel> Camels { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Cattle> Cattle { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.SmallCattle> SmallCattles { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.Horse> Horses { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.species1> species1 { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.species2> species2 { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.species3> species3 { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.CATOSpecies> CATOSpecies { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.WType> WTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.ChemicalComp> ChemicalComps { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.WSubType> WSubTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.wellspnt> wellspnt { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.BurOtdel> BurOtdels { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.BType> BTypes { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.BurSubOtdel> BurSubOtdels { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.BClass> BClasses { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.BGroup> BGroups { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.burden_pasture> burden_pasture { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.WClass> WClasses { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.wellspol> wellspol { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.pasturestat> pasturestat { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.SupplyRecommend> SupplyRecommends { get; set; }

        public System.Data.Entity.DbSet<Pastures.Models.SType> STypes { get; set; }
    }
}