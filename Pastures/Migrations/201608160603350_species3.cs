namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class species3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.species1", "conditional", c => c.Int(nullable: false));
            AlterColumn("public.species2", "conditional", c => c.Int(nullable: false));
            AlterColumn("public.species3", "conditional", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.species3", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            AlterColumn("public.species2", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
            AlterColumn("public.species1", "conditional", c => c.Decimal(nullable: false, precision: 29, scale: 19));
        }
    }
}
