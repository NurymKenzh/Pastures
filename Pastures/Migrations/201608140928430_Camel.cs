namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Camel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Camels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Breed = c.String(),
                        Weight = c.String(),
                        SlaughterYield = c.Decimal(nullable: false, precision: 29, scale: 19),
                        EwesYield = c.String(),
                        TotalGoals = c.Int(nullable: false),
                        MilkFatContent = c.String(),
                        Range = c.String(),
                        Photo = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Camels");
        }
    }
}
