namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PType1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("public.PTypes", "Description", c => c.String());
            //DropColumn("public.PTypes", "Transcript");
        }
        
        public override void Down()
        {
            //AddColumn("public.PTypes", "Transcript", c => c.String());
            //DropColumn("public.PTypes", "Description");
        }
    }
}
