namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesNew1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Species", "population", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Species", "population");
        }
    }
}
