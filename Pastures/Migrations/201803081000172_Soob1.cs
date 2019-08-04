namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Soob1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Soobs", "DescriptionLat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Soobs", "DescriptionLat");
        }
    }
}
