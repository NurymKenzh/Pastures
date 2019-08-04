namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesOld1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.species1", "population", c => c.Int());
            AddColumn("public.species1", "pastures", c => c.Int());
            AddColumn("public.species2", "totalgoals", c => c.Int());
            AddColumn("public.species2", "cattle", c => c.Int());
            AddColumn("public.species2", "horses", c => c.Int());
            AddColumn("public.species2", "smallcattle", c => c.Int());
            AddColumn("public.species2", "camels", c => c.Int());
            AddColumn("public.species2", "conditional", c => c.Decimal(precision: 29, scale: 19));
            AddColumn("public.species2", "date", c => c.String());
            AddColumn("public.species2", "source", c => c.Int());
            AddColumn("public.species2", "population", c => c.Int());
            AddColumn("public.species2", "pastures", c => c.Int());
            AddColumn("public.species3", "population", c => c.Int());
            AddColumn("public.species3", "pastures", c => c.Int());
            AlterColumn("public.Species", "conditional", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("public.species1", "totalgoals", c => c.Int());
            AlterColumn("public.species1", "cattle", c => c.Int());
            AlterColumn("public.species1", "horses", c => c.Int());
            AlterColumn("public.species1", "smallcattle", c => c.Int());
            AlterColumn("public.species1", "camels", c => c.Int());
            AlterColumn("public.species1", "conditional", c => c.Decimal(precision: 29, scale: 19));
            AlterColumn("public.species3", "totalgoals", c => c.Int());
            AlterColumn("public.species3", "cattle", c => c.Int());
            AlterColumn("public.species3", "horses", c => c.Int());
            AlterColumn("public.species3", "smallcattle", c => c.Int());
            AlterColumn("public.species3", "camels", c => c.Int());
            AlterColumn("public.species3", "conditional", c => c.Decimal(precision: 29, scale: 19));
        }
        
        public override void Down()
        {
            AlterColumn("public.species3", "conditional", c => c.Int(nullable: false));
            AlterColumn("public.species3", "camels", c => c.Int(nullable: false));
            AlterColumn("public.species3", "smallcattle", c => c.Int(nullable: false));
            AlterColumn("public.species3", "horses", c => c.Int(nullable: false));
            AlterColumn("public.species3", "cattle", c => c.Int(nullable: false));
            AlterColumn("public.species3", "totalgoals", c => c.Int(nullable: false));
            AlterColumn("public.species1", "conditional", c => c.Int(nullable: false));
            AlterColumn("public.species1", "camels", c => c.Int(nullable: false));
            AlterColumn("public.species1", "smallcattle", c => c.Int(nullable: false));
            AlterColumn("public.species1", "horses", c => c.Int(nullable: false));
            AlterColumn("public.species1", "cattle", c => c.Int(nullable: false));
            AlterColumn("public.species1", "totalgoals", c => c.Int(nullable: false));
            AlterColumn("public.Species", "conditional", c => c.Decimal(precision: 29, scale: 19));
            DropColumn("public.species3", "pastures");
            DropColumn("public.species3", "population");
            DropColumn("public.species2", "pastures");
            DropColumn("public.species2", "population");
            DropColumn("public.species2", "source");
            DropColumn("public.species2", "date");
            DropColumn("public.species2", "conditional");
            DropColumn("public.species2", "camels");
            DropColumn("public.species2", "smallcattle");
            DropColumn("public.species2", "horses");
            DropColumn("public.species2", "cattle");
            DropColumn("public.species2", "totalgoals");
            DropColumn("public.species1", "pastures");
            DropColumn("public.species1", "population");
        }
    }
}
