namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasturestat1 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("public.pasturestat", "objectid", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "class_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "relief_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "zone_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "subtype_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "group_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "recommend_", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "recom_catt", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "haying_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            //AlterColumn("public.pasturestat", "otdely_id", c => c.Decimal(nullable: false, precision: 29, scale: 19));
        }
        
        public override void Down()
        {
            //AlterColumn("public.pasturestat", "otdely_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "haying_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "recom_catt", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "recommend_", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "group_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "subtype_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "zone_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "relief_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "class_id", c => c.Int(nullable: false));
            //AlterColumn("public.pasturestat", "objectid", c => c.Int(nullable: false));
        }
    }
}
