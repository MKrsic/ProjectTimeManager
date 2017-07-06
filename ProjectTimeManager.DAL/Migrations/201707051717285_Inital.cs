namespace ProjectTimeManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Project_ID = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.Person_ID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.TimeTracks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Project_ID = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.Person_ID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeTracks", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.TimeTracks", "Person_ID", "dbo.People");
            DropForeignKey("dbo.ProjectMembers", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.ProjectMembers", "Person_ID", "dbo.People");
            DropIndex("dbo.TimeTracks", new[] { "Person_ID" });
            DropIndex("dbo.TimeTracks", new[] { "Project_ID" });
            DropIndex("dbo.ProjectMembers", new[] { "Person_ID" });
            DropIndex("dbo.ProjectMembers", new[] { "Project_ID" });
            DropTable("dbo.TimeTracks");
            DropTable("dbo.ProjectMembers");
            DropTable("dbo.Projects");
            DropTable("dbo.People");
        }
    }
}
