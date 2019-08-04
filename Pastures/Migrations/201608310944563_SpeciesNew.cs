namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CATO = c.String(),
                        totalgoals = c.Int(nullable: false),
                        cattle = c.Int(nullable: false),
                        horses = c.Int(nullable: false),
                        smallcattle = c.Int(nullable: false),
                        camels = c.Int(nullable: false),
                        conditional = c.Int(nullable: false),
                        date = c.String(),
                        source = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Species");
        }
    }
}
