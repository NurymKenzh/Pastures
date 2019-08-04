namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesNew2 : DbMigration
    {
        public override void Up()
        {
            DropTable("public.Species");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CATO = c.String(),
                        population = c.Int(),
                        pastures = c.Int(),
                        totalgoals = c.Int(),
                        cattle = c.Int(),
                        horses = c.Int(),
                        smallcattle = c.Int(),
                        camels = c.Int(),
                        conditional = c.Decimal(precision: 18, scale: 2),
                        date = c.String(),
                        source = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
