namespace EscutaSom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeira_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        banda_Id = c.Int(nullable: false),
                        banda_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bandas", t => t.banda_Id1)
                .Index(t => t.banda_Id1);
            
            CreateTable(
                "dbo.Bandas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        QuantIntegrantes = c.Int(nullable: false),
                        gravadora_Id = c.Int(nullable: false),
                        gravadora_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gravadoras", t => t.gravadora_Id1)
                .Index(t => t.gravadora_Id1);
            
            CreateTable(
                "dbo.Gravadoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CNPJ = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Cpf = c.String(),
                        banda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bandas", t => t.banda_Id)
                .Index(t => t.banda_Id);
            
            CreateTable(
                "dbo.Instrumentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        TipoInstrumento = c.String(),
                        musico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musicoes", t => t.musico_Id)
                .Index(t => t.musico_Id);
            
            CreateTable(
                "dbo.Faixas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DuracaoMusica = c.Double(nullable: false),
                        CriacaoMusica = c.DateTime(nullable: false),
                        album_Id = c.Int(nullable: false),
                        album_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.album_Id1)
                .Index(t => t.album_Id1);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Faixas", new[] { "album_Id1" });
            DropIndex("dbo.Instrumentoes", new[] { "musico_Id" });
            DropIndex("dbo.Musicoes", new[] { "banda_Id" });
            DropIndex("dbo.Bandas", new[] { "gravadora_Id1" });
            DropIndex("dbo.Albums", new[] { "banda_Id1" });
            DropForeignKey("dbo.Faixas", "album_Id1", "dbo.Albums");
            DropForeignKey("dbo.Instrumentoes", "musico_Id", "dbo.Musicoes");
            DropForeignKey("dbo.Musicoes", "banda_Id", "dbo.Bandas");
            DropForeignKey("dbo.Bandas", "gravadora_Id1", "dbo.Gravadoras");
            DropForeignKey("dbo.Albums", "banda_Id1", "dbo.Bandas");
            DropTable("dbo.Faixas");
            DropTable("dbo.Instrumentoes");
            DropTable("dbo.Musicoes");
            DropTable("dbo.Gravadoras");
            DropTable("dbo.Bandas");
            DropTable("dbo.Albums");
        }
    }
}
