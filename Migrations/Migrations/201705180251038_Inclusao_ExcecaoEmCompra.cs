namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inclusao_ExcecaoEmCompra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcecaoNF",
                c => new
                    {
                        IdExcecaoNF = c.Long(nullable: false, identity: true),
                        IdCompra = c.Long(nullable: false),
                        IdPedidoItemFornecedor = c.Long(nullable: false),
                        QuantidadeAguardada = c.Int(nullable: false),
                        QuantidadeRecebida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExcecaoNF)
                .ForeignKey("dbo.Compra", t => t.IdCompra)
                .ForeignKey("dbo.PedidoItemFornecedor", t => t.IdPedidoItemFornecedor)
                .Index(t => t.IdCompra)
                .Index(t => t.IdPedidoItemFornecedor);
            
            DropTable("dbo.PedidoFornecedor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PedidoFornecedor",
                c => new
                    {
                        IdPedidoFornecedor = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdPedidoFornecedor);
            
            DropForeignKey("dbo.ExcecaoNF", "IdPedidoItemFornecedor", "dbo.PedidoItemFornecedor");
            DropForeignKey("dbo.ExcecaoNF", "IdCompra", "dbo.Compra");
            DropIndex("dbo.ExcecaoNF", new[] { "IdPedidoItemFornecedor" });
            DropIndex("dbo.ExcecaoNF", new[] { "IdCompra" });
            DropTable("dbo.ExcecaoNF");
        }
    }
}
