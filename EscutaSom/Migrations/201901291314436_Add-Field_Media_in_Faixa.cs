namespace EscutaSom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddField_Media_in_Faixa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faixas", "Media", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faixas", "Media");
        }
    }
}
