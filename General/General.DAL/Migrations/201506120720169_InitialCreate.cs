namespace General.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.it_SystemButton");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.it_SystemButton",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        ButtonCode = c.String(),
                        Description = c.String(),
                        IsLock = c.Boolean(nullable: false),
                        LastUpadateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
