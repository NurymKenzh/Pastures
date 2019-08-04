namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class burden_pasture : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.burden_pasture",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            num_vydel = c.Int(nullable: false),
            //            rule_grazi = c.Int(nullable: false),
            //            bur_otdel = c.Int(nullable: false),
            //            bur_type_i = c.Int(nullable: false),
            //            bur_subotd = c.Int(nullable: false),
            //            bur_class_ = c.Int(nullable: false),
            //            bur_group_ = c.Int(nullable: false),
            //            average_yi = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            burden_gro = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            burden_deg = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.burden_pasture");
        }
    }
}
