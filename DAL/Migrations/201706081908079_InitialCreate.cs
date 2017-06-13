namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LearnersCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        LastRepetition = c.DateTime(nullable: false),
                        Rating = c.Byte(nullable: false),
                        Learner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Learners", t => t.Learner_Id)
                .Index(t => t.Learner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LearnersCards", "Learner_Id", "dbo.Learners");
            DropIndex("dbo.LearnersCards", new[] { "Learner_Id" });
            DropTable("dbo.LearnersCards");
            DropTable("dbo.Learners");
        }
    }
}
