namespace EscutaSom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_Modelo_Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Username = c.String(),
                        Senha = c.String(),
                        ConfirmarSenha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
