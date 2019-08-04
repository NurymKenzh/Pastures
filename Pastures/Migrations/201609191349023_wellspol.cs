namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wellspol : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.wellspol",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            class_id = c.Int(nullable: false),
            //            shape_leng = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            shape_area = c.Decimal(nullable: false, precision: 29, scale: 19),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.wellspol");
        }
    }
}
