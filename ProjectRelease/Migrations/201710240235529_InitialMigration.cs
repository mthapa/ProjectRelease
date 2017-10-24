namespace ProjectRelease.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        AgencyId = c.Int(nullable: false, identity: true),
                        AgencyCode = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AgencyId);
            
            CreateTable(
                "dbo.Deployments",
                c => new
                    {
                        DeploymentId = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                        Date = c.DateTime(nullable: false),
                        Environment = c.Int(nullable: false),
                        Remarks = c.String(),
                        Agency_AgencyId = c.Int(),
                    })
                .PrimaryKey(t => t.DeploymentId)
                .ForeignKey("dbo.Agencies", t => t.Agency_AgencyId)
                .Index(t => t.Agency_AgencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deployments", "Agency_AgencyId", "dbo.Agencies");
            DropIndex("dbo.Deployments", new[] { "Agency_AgencyId" });
            DropTable("dbo.Deployments");
            DropTable("dbo.Agencies");
        }
    }
}
