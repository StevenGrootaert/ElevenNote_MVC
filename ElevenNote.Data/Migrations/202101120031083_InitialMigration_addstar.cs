namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration_addstar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "IsStared", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "IsStared");
        }
    }
}
