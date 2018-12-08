namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnsdrop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RelationTypes", "InRealtionTime");
            DropColumn("dbo.RelationTypes", "RelationQuality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RelationTypes", "RelationQuality", c => c.Int(nullable: false));
            AddColumn("dbo.RelationTypes", "InRealtionTime", c => c.Int(nullable: false));
        }
    }
}
