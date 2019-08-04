namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasturesNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Species", "pastures", c => c.Int());
            AlterColumn("public.Species", "population", c => c.Int());
            AlterColumn("public.Species", "totalgoals", c => c.Int());
            AlterColumn("public.Species", "cattle", c => c.Int());
            AlterColumn("public.Species", "horses", c => c.Int());
            AlterColumn("public.Species", "smallcattle", c => c.Int());
            AlterColumn("public.Species", "camels", c => c.Int());
            AlterColumn("public.Species", "conditional", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("public.Species", "conditional", c => c.Int(nullable: false));
            AlterColumn("public.Species", "camels", c => c.Int(nullable: false));
            AlterColumn("public.Species", "smallcattle", c => c.Int(nullable: false));
            AlterColumn("public.Species", "horses", c => c.Int(nullable: false));
            AlterColumn("public.Species", "cattle", c => c.Int(nullable: false));
            AlterColumn("public.Species", "totalgoals", c => c.Int(nullable: false));
            AlterColumn("public.Species", "population", c => c.Int(nullable: false));
            DropColumn("public.Species", "pastures");
        }
    }
}
