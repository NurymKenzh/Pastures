namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wellspnt : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "public.wellspnt",
            //    c => new
            //        {
            //            gid = c.Int(nullable: false, identity: true),
            //            objectid = c.Int(nullable: false),
            //            id = c.Int(nullable: false),
            //            num = c.String(),
            //            usl = c.Int(nullable: false),
            //            indeks = c.String(),
            //            debit = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            decrease = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            depth = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            minerali = c.Decimal(nullable: false, precision: 29, scale: 19),
            //            chemical_c = c.Int(nullable: false),
            //            kato = c.String(),
            //            wat_seepag = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.gid);
            
        }
        
        public override void Down()
        {
            //DropTable("public.wellspnt");
        }
    }
}
