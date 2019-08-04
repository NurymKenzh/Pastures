namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BurSubOtdel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.BurSubOtdels",
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
            DropTable("public.BurSubOtdels");
        }
    }
}
