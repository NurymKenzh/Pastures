namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesOld : DbMigration
    {
        public override void Up()
        {
            //AddColumn("public.species2", "name_obl", c => c.String());
            //AddColumn("public.species2", "cd", c => c.Int(nullable: false));
            //AddColumn("public.species2", "name", c => c.String());
            //AddColumn("public.species2", "kato", c => c.String());
            //DropColumn("public.species2", "name_adm1");
            //DropColumn("public.species2", "name_adm2");
            //DropColumn("public.species2", "kato_te");
            //DropColumn("public.species2", "totalgoals");
            //DropColumn("public.species2", "cattle");
            //DropColumn("public.species2", "horses");
            //DropColumn("public.species2", "smallcattle");
            //DropColumn("public.species2", "camels");
            //DropColumn("public.species2", "conditional");
            //DropColumn("public.species2", "date");
            //DropColumn("public.species2", "source");
        }
        
        public override void Down()
        {
            //AddColumn("public.species2", "source", c => c.Int());
            //AddColumn("public.species2", "date", c => c.String());
            //AddColumn("public.species2", "conditional", c => c.Int(nullable: false));
            //AddColumn("public.species2", "camels", c => c.Int(nullable: false));
            //AddColumn("public.species2", "smallcattle", c => c.Int(nullable: false));
            //AddColumn("public.species2", "horses", c => c.Int(nullable: false));
            //AddColumn("public.species2", "cattle", c => c.Int(nullable: false));
            //AddColumn("public.species2", "totalgoals", c => c.Int(nullable: false));
            //AddColumn("public.species2", "kato_te", c => c.String());
            //AddColumn("public.species2", "name_adm2", c => c.String());
            //AddColumn("public.species2", "name_adm1", c => c.String());
            //DropColumn("public.species2", "kato");
            //DropColumn("public.species2", "name");
            //DropColumn("public.species2", "cd");
            //DropColumn("public.species2", "name_obl");
        }
    }
}
