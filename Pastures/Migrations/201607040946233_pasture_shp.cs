namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasture_shp : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.pasture_shp",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            id_pasture = c.Int(nullable: false),
            //            kato = c.String(),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.pasture_shp");
        }
    }
}
