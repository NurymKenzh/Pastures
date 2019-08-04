namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class species2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.species1", "source", c => c.Int());
            AlterColumn("public.species2", "source", c => c.Int());
            AlterColumn("public.species3", "source", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("public.species3", "source", c => c.Int(nullable: false));
            AlterColumn("public.species2", "source", c => c.Int(nullable: false));
            AlterColumn("public.species1", "source", c => c.Int(nullable: false));
        }
    }
}
