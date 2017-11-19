namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CategoriaId = c.Long(),
                        FabricanteId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.Fabricante", t => t.FabricanteId)
                .Index(t => t.CategoriaId)
                .Index(t => t.FabricanteId);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "FabricanteId", "dbo.Fabricante");
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "FabricanteId" });
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.Fabricante");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
