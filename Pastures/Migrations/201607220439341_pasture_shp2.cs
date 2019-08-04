namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasture_shp2 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.pasture_shp",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            type_id = c.Int(nullable: false),
            //            relief_id = c.Int(nullable: false),
            //            zone_id = c.Int(nullable: false),
            //            subtype_id = c.Int(nullable: false),
            //            soob_id = c.Int(nullable: false),
            //            kato = c.String(),
            //            catoid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.pasture_shp");
        }
    }
}
