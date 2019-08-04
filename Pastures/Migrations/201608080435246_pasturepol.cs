namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasturepol : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.pasturepol",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            class_id = c.Int(nullable: false),
            //            relief_id = c.Int(nullable: false),
            //            zone_id = c.Int(nullable: false),
            //            subtype_id = c.Int(nullable: false),
            //            group_id = c.Int(nullable: false),
            //            ur_v = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            ur_l = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            ur_o = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            ur_z = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            korm_v = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            korm_l = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            korm_o = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            korm_z = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            recommend_ = c.Int(nullable: false),
            //            recom_catt = c.Int(nullable: false),
            //            haying_id = c.Int(nullable: false),
            //            otdely_id = c.Int(nullable: false),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.pasturepol");
        }
    }
}
