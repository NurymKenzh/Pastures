namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasturesNew1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Species", "conditional", c => c.Decimal(precision: 29, scale: 19));
        }
        
        public override void Down()
        {
            AlterColumn("public.Species", "conditional", c => c.Int());
        }
    }
}
