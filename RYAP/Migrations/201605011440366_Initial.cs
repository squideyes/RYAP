namespace RYAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Location = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "IX_Author_Email")
                .Index(t => t.Name, unique: true, name: "IX_Author_Name");
            
            CreateTable(
                "dbo.Jokes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 100, unicode: false),
                        Answer = c.String(nullable: false, maxLength: 200, unicode: false),
                        AddedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.Question, unique: true, name: "IX_Joke_Question")
                .Index(t => t.AddedOn, name: "IX_Joke_AddedOn");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jokes", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Jokes", "IX_Joke_AddedOn");
            DropIndex("dbo.Jokes", "IX_Joke_Question");
            DropIndex("dbo.Jokes", new[] { "AuthorId" });
            DropIndex("dbo.Authors", "IX_Author_Name");
            DropIndex("dbo.Authors", "IX_Author_Email");
            DropTable("dbo.Jokes");
            DropTable("dbo.Authors");
        }
    }
}
