namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zemfondpol : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.zemfondpol",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            type_k = c.Int(nullable: false),
            //            ur_avgyear = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            dominant_t = c.Int(nullable: false),
            //            korm_avgye = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            s_recomend = c.Int(nullable: false),
            //            subtype_k = c.Int(nullable: false),
            //            kato_te_1 = c.String(),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.zemfondpol");
        }
    }
}
