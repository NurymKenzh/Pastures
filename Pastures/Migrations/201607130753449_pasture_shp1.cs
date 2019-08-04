namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasture_shp1 : DbMigration
    {
        public override void Up()
        {
            DropTable("public.pasture_shp");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.pasture_shp",
                c => new
                    {
                        gid = c.Int(nullable: false, identity: true),
                        objectid = c.Int(nullable: false),
                        id_pasture = c.Int(nullable: false),
                        kato = c.String(),
                    })
                .PrimaryKey(t => t.gid);
            
        }
    }
}
