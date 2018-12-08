namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Mobile = c.String(maxLength: 10),
                        Email = c.String(),
                        RelationTypeId = c.Int(nullable: false),
                        Address = c.String(),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RelationTypes", t => t.RelationTypeId, cascadeDelete: true)
                .Index(t => t.RelationTypeId);
            
            CreateTable(
                "dbo.RelationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        InRealtionTime = c.Int(nullable: false),
                        RelationQuality = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "RelationTypeId", "dbo.RelationTypes");
            DropIndex("dbo.People", new[] { "RelationTypeId" });
            DropTable("dbo.RelationTypes");
            DropTable("dbo.People");
        }
    }
}
