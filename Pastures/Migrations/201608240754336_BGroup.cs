namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.BGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.BGroups");
        }
    }
}
