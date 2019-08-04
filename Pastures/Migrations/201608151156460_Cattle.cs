namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cattle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Cattles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Breed = c.String(),
                        Direction = c.String(),
                        Weight = c.String(),
                        SlaughterYield = c.String(),
                        EwesYield = c.String(),
                        TotalGoals = c.Int(nullable: false),
                        MilkFatContent = c.String(),
                        Bred = c.String(),
                        Range = c.String(),
                        Photo = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Horses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Breed = c.String(),
                        Direction = c.String(),
                        Weight = c.String(),
                        Height = c.String(),
                        MilkYield = c.String(),
                        BodyLength = c.String(),
                        Bust = c.String(),
                        TotalGoals = c.Int(nullable: false),
                        Bred = c.String(),
                        Range = c.String(),
                        Photo = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.SmallCattles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Breed = c.String(),
                        Direction = c.String(),
                        Weight = c.String(),
                        Shearings = c.String(),
                        WashedWoolYield = c.String(),
                        Fertility = c.String(),
                        WoolLength = c.String(),
                        TotalGoals = c.Int(nullable: false),
                        Bred = c.String(),
                        Range = c.String(),
                        Photo = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.SmallCattles");
            DropTable("public.Horses");
            DropTable("public.Cattles");
        }
    }
}
