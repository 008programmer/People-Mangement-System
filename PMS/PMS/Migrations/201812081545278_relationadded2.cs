namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationadded2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeopleRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationTypeId = c.Int(nullable: false),
                        InRelationTime = c.Int(),
                        RelationQuality = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RelationTypes", t => t.RelationTypeId, cascadeDelete: true)
                .Index(t => t.RelationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleRelations", "RelationTypeId", "dbo.RelationTypes");
            DropIndex("dbo.PeopleRelations", new[] { "RelationTypeId" });
            DropTable("dbo.PeopleRelations");
        }
    }
}
