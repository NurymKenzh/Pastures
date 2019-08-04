namespace Pastures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CATO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Catoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AB = c.String(),
                        CD = c.String(),
                        EF = c.String(),
                        HIJ = c.String(),
                        K = c.String(),
                        Name = c.String(),
                        NameKZ = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Catoes");
        }
    }
}
