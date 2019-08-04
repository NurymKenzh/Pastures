namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class species : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.species1",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            name_cntr = c.String(),
            //            name_adm1 = c.String(),
            //            kato_te = c.String(),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
            //CreateTable(
            //    "public.species2",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            name_adm1 = c.String(),
            //            name_adm2 = c.String(),
            //            kato_te = c.String(),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
            //CreateTable(
            //    "public.species3",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            name_adm1 = c.String(),
            //            name_adm2 = c.String(),
            //            kato_te = c.String(),
            //            type_k = c.Int(nullable: false),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            name_adm3 = c.String(),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.species3");
            //DropTable("public.species2");
            //DropTable("public.species1");
        }
    }
}
