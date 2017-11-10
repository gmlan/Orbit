namespace Com.Qualcomm.Qswat.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableAssignee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.Users");
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            AlterColumn("dbo.Issues", "AssigneeId", c => c.Int());
            CreateIndex("dbo.Issues", "AssigneeId");
            AddForeignKey("dbo.Issues", "AssigneeId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "AssigneeId", "dbo.Users");
            DropIndex("dbo.Issues", new[] { "AssigneeId" });
            AlterColumn("dbo.Issues", "AssigneeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "AssigneeId");
            AddForeignKey("dbo.Issues", "AssigneeId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
