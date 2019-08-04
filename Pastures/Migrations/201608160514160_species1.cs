namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class species1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.species1", "totalgoals", c => c.Int(nullable: false));
            AddColumn("public.species1", "cattle", c => c.Int(nullable: false));
            AddColumn("public.species1", "horses", c => c.Int(nullable: false));
            AddColumn("public.species1", "smallcattle", c => c.Int(nullable: false));
            AddColumn("public.species1", "camels", c => c.Int(nullable: false));
            AddColumn("public.species1", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            AddColumn("public.species1", "date", c => c.String());
            AddColumn("public.species1", "source", c => c.Int(nullable: false));
            AddColumn("public.species2", "totalgoals", c => c.Int(nullable: false));
            AddColumn("public.species2", "cattle", c => c.Int(nullable: false));
            AddColumn("public.species2", "horses", c => c.Int(nullable: false));
            AddColumn("public.species2", "smallcattle", c => c.Int(nullable: false));
            AddColumn("public.species2", "camels", c => c.Int(nullable: false));
            AddColumn("public.species2", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            AddColumn("public.species2", "date", c => c.String());
            AddColumn("public.species2", "source", c => c.Int(nullable: false));
            AddColumn("public.species3", "totalgoals", c => c.Int(nullable: false));
            AddColumn("public.species3", "cattle", c => c.Int(nullable: false));
            AddColumn("public.species3", "horses", c => c.Int(nullable: false));
            AddColumn("public.species3", "smallcattle", c => c.Int(nullable: false));
            AddColumn("public.species3", "camels", c => c.Int(nullable: false));
            AddColumn("public.species3", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            AddColumn("public.species3", "date", c => c.String());
            AddColumn("public.species3", "source", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.species3", "source");
            DropColumn("public.species3", "date");
            DropColumn("public.species3", "conditional");
            DropColumn("public.species3", "camels");
            DropColumn("public.species3", "smallcattle");
            DropColumn("public.species3", "horses");
            DropColumn("public.species3", "cattle");
            DropColumn("public.species3", "totalgoals");
            DropColumn("public.species2", "source");
            DropColumn("public.species2", "date");
            DropColumn("public.species2", "conditional");
            DropColumn("public.species2", "camels");
            DropColumn("public.species2", "smallcattle");
            DropColumn("public.species2", "horses");
            DropColumn("public.species2", "cattle");
            DropColumn("public.species2", "totalgoals");
            DropColumn("public.species1", "source");
            DropColumn("public.species1", "date");
            DropColumn("public.species1", "conditional");
            DropColumn("public.species1", "camels");
            DropColumn("public.species1", "smallcattle");
            DropColumn("public.species1", "horses");
            DropColumn("public.species1", "cattle");
            DropColumn("public.species1", "totalgoals");
        }
    }
}
