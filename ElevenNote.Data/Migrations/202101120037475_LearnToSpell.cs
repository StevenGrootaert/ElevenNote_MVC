namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LearnToSpell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "IsStarred", c => c.Boolean(nullable: false));
            DropColumn("dbo.Note", "IsStared");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "IsStared", c => c.Boolean(nullable: false));
            DropColumn("dbo.Note", "IsStarred");
        }
    }
}
