namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasture_tab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.pasture_tab",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        objectid = c.Int(nullable: false),
                        type_id = c.Int(nullable: false),
                        relief_id = c.Int(nullable: false),
                        zone_id = c.Int(nullable: false),
                        subtype_id = c.Int(nullable: false),
                        soob_id = c.Int(nullable: false),
                        ur_v = c.Decimal(nullable: false, precision: 29, scale: 19),
                        ur_l = c.Decimal(nullable: false, precision: 29, scale: 19),
                        ur_o = c.Decimal(nullable: false, precision: 29, scale: 19),
                        ur_z = c.Decimal(nullable: false, precision: 29, scale: 19),
                        korm_v = c.Decimal(nullable: false, precision: 29, scale: 19),
                        korm_l = c.Decimal(nullable: false, precision: 29, scale: 19),
                        korm_o = c.Decimal(nullable: false, precision: 29, scale: 19),
                        korm_z = c.Decimal(nullable: false, precision: 29, scale: 19),
                        recom_id = c.Int(nullable: false),
                        recom_cat_id = c.Int(nullable: false),
                        haying = c.Decimal(nullable: false, precision: 29, scale: 19),
                        idfrommap = c.Int(nullable: false),
                        dopznk = c.Int(nullable: false),
                        kato = c.String(),
                        catoid = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("public.pasture_tab");
        }
    }
}
