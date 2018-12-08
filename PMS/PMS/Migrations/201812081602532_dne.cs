namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeopleRelations", "RelationTypeId", "dbo.RelationTypes");
            DropIndex("dbo.PeopleRelations", new[] { "RelationTypeId" });
            DropTable("dbo.PeopleRelations");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PeopleRelations", "RelationTypeId");
            AddForeignKey("dbo.PeopleRelations", "RelationTypeId", "dbo.RelationTypes", "Id", cascadeDelete: true);
        }
    }
}
