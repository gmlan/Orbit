namespace Com.Qualcomm.Qswat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        Severity = c.Int(nullable: false),
                        AssigneeId = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        DueDateUtc = c.DateTime(),
                        CreateDateTimeUtc = c.DateTime(nullable: false),
                        LastModifiedUtc = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssigneeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .Index(t => t.AssigneeId)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 32),
                        LastName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Phone = c.String(maxLength: 12),
                        PasswordHash = c.String(nullable: false, maxLength: 32),
                        AddressLine1 = c.String(nullable: false, maxLength: 255),
                        AddressLine2 = c.String(maxLength: 255),
                        AddressLine3 = c.String(maxLength: 255),
                        City = c.String(nullable: false, maxLength: 32),
                        State = c.String(nullable: false, maxLength: 32),
                        Country = c.String(nullable: false, maxLength: 32),
                        PostalCode = c.String(nullable: false, maxLength: 12),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.Users");
            DropIndex("dbo.Issues", new[] { "CreatedById" });
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Issues");
        }
    }
}
