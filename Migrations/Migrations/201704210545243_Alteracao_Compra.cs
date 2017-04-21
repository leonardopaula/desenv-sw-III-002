namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Compra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compra", "IdPedidoFornecedor", "dbo.PedidoFornecedor");
            DropForeignKey("dbo.CompraProduto", "IdCompra", "dbo.Compra");
            DropForeignKey("dbo.CompraProduto", "IdProduto", "dbo.Produto");
            DropIndex("dbo.Compra", new[] { "IdPedidoFornecedor" });
            DropIndex("dbo.CompraProduto", new[] { "IdCompra" });
            DropIndex("dbo.CompraProduto", new[] { "IdProduto" });
            CreateTable(
                "dbo.CompraPedidos",
                c => new
                    {
                        IdCompra = c.Long(nullable: false),
                        IdPedidoItemFornecedor = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCompra, t.IdPedidoItemFornecedor })
                .ForeignKey("dbo.Compra", t => t.IdCompra)
                .ForeignKey("dbo.PedidoItemFornecedor", t => t.IdPedidoItemFornecedor)
                .Index(t => t.IdCompra)
                .Index(t => t.IdPedidoItemFornecedor);
            
            AddColumn("dbo.Compra", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Compra", "IdPedidoFornecedor");
            DropColumn("dbo.PedidoFornecedor", "Status");
            DropTable("dbo.CompraProduto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompraProduto",
                c => new
                    {
                        IdCompra = c.Long(nullable: false),
                        IdProduto = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCompra, t.IdProduto });
            
            AddColumn("dbo.PedidoFornecedor", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Compra", "IdPedidoFornecedor", c => c.Long(nullable: false));
            DropForeignKey("dbo.CompraPedidos", "IdPedidoItemFornecedor", "dbo.PedidoItemFornecedor");
            DropForeignKey("dbo.CompraPedidos", "IdCompra", "dbo.Compra");
            DropIndex("dbo.CompraPedidos", new[] { "IdPedidoItemFornecedor" });
            DropIndex("dbo.CompraPedidos", new[] { "IdCompra" });
            DropColumn("dbo.Compra", "Status");
            DropTable("dbo.CompraPedidos");
            CreateIndex("dbo.CompraProduto", "IdProduto");
            CreateIndex("dbo.CompraProduto", "IdCompra");
            CreateIndex("dbo.Compra", "IdPedidoFornecedor");
            AddForeignKey("dbo.CompraProduto", "IdProduto", "dbo.Produto", "IdProduto");
            AddForeignKey("dbo.CompraProduto", "IdCompra", "dbo.Compra", "IdCompra");
            AddForeignKey("dbo.Compra", "IdPedidoFornecedor", "dbo.PedidoFornecedor", "IdPedidoFornecedor");
        }
    }
}
