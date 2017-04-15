namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        IdCompra = c.Long(nullable: false, identity: true),
                        NumeroNF = c.Int(),
                        Data = c.DateTime(nullable: false),
                        IdPedidoFornecedor = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompra);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        IdProduto = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Peso = c.Single(nullable: false),
                        QuantidadeEmEstoque = c.Int(nullable: false),
                        QuantidadeEstoqueMinimo = c.Int(nullable: false),
                        Referencia = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        IdFornecedor = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdFornecedor);
            
            CreateTable(
                "dbo.Faturamento",
                c => new
                    {
                        IdFaturamento = c.Long(nullable: false),
                        IdPedidoCliente = c.Long(nullable: false),
                        IdPagamento = c.Long(nullable: false),
                        IdNotaFiscal = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdFaturamento)
                .ForeignKey("dbo.NotaFiscal", t => t.IdFaturamento)
                .ForeignKey("dbo.Pagamento", t => t.IdFaturamento)
                .ForeignKey("dbo.PedidoCliente", t => t.IdFaturamento)
                .Index(t => t.IdFaturamento);
            
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        IdNotaFiscal = c.Long(nullable: false, identity: true),
                        Impostos = c.Decimal(nullable: false, precision: 10, scale: 3),
                        ValorTotal = c.Decimal(nullable: false, precision: 10, scale: 3),
                    })
                .PrimaryKey(t => t.IdNotaFiscal);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        IdPagamento = c.Long(nullable: false, identity: true),
                        MeioPagamento = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Origem = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdPagamento);
            
            CreateTable(
                "dbo.PedidoCliente",
                c => new
                    {
                        IdPedidoCliente = c.Long(nullable: false, identity: true),
                        CodigoRastreio = c.String(maxLength: 150, unicode: false),
                        Status = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        NumDocPag = c.Int(),
                        IdCliente = c.Long(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedidoCliente)
                .ForeignKey("dbo.Cliente", t => t.IdCliente)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.PedidoFornecedor",
                c => new
                    {
                        IdPedidoFornecedor = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedidoFornecedor);
            
            CreateTable(
                "dbo.PedidoItemFornecedor",
                c => new
                    {
                        IdPedidoItemFornecedor = c.Long(nullable: false, identity: true),
                        IdProduto = c.Long(nullable: false),
                        IdFornecedor = c.Long(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DataPrevista = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedidoItemFornecedor)
                .ForeignKey("dbo.Fornecedor", t => t.IdFornecedor)
                .ForeignKey("dbo.Produto", t => t.IdProduto)
                .Index(t => t.IdProduto)
                .Index(t => t.IdFornecedor);
            
            CreateTable(
                "dbo.FornecedorProduto",
                c => new
                    {
                        IdProduto = c.Long(nullable: false),
                        IdFornecedor = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProduto, t.IdFornecedor })
                .ForeignKey("dbo.Fornecedor", t => t.IdProduto)
                .ForeignKey("dbo.Produto", t => t.IdFornecedor)
                .Index(t => t.IdProduto)
                .Index(t => t.IdFornecedor);
            
            CreateTable(
                "dbo.CompraProduto",
                c => new
                    {
                        IdCompra = c.Long(nullable: false),
                        IdProduto = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCompra, t.IdProduto })
                .ForeignKey("dbo.Compra", t => t.IdCompra)
                .ForeignKey("dbo.Produto", t => t.IdProduto)
                .Index(t => t.IdCompra)
                .Index(t => t.IdProduto);
            
            CreateTable(
                "dbo.PedidoCliente_Produtos",
                c => new
                    {
                        IdPedidoCliente = c.Long(nullable: false),
                        IdProduto = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdPedidoCliente, t.IdProduto })
                .ForeignKey("dbo.PedidoCliente", t => t.IdPedidoCliente)
                .ForeignKey("dbo.Produto", t => t.IdProduto)
                .Index(t => t.IdPedidoCliente)
                .Index(t => t.IdProduto);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.Long(nullable: false),
                        Rg = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Matricula = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItemFornecedor", "IdProduto", "dbo.Produto");
            DropForeignKey("dbo.PedidoItemFornecedor", "IdFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.PedidoCliente");
            DropForeignKey("dbo.PedidoCliente_Produtos", "IdProduto", "dbo.Produto");
            DropForeignKey("dbo.PedidoCliente_Produtos", "IdPedidoCliente", "dbo.PedidoCliente");
            DropForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.Pagamento");
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.NotaFiscal");
            DropForeignKey("dbo.CompraProduto", "IdProduto", "dbo.Produto");
            DropForeignKey("dbo.CompraProduto", "IdCompra", "dbo.Compra");
            DropForeignKey("dbo.FornecedorProduto", "IdFornecedor", "dbo.Produto");
            DropForeignKey("dbo.FornecedorProduto", "IdProduto", "dbo.Fornecedor");
            DropIndex("dbo.PedidoCliente_Produtos", new[] { "IdProduto" });
            DropIndex("dbo.PedidoCliente_Produtos", new[] { "IdPedidoCliente" });
            DropIndex("dbo.CompraProduto", new[] { "IdProduto" });
            DropIndex("dbo.CompraProduto", new[] { "IdCompra" });
            DropIndex("dbo.FornecedorProduto", new[] { "IdFornecedor" });
            DropIndex("dbo.FornecedorProduto", new[] { "IdProduto" });
            DropIndex("dbo.PedidoItemFornecedor", new[] { "IdFornecedor" });
            DropIndex("dbo.PedidoItemFornecedor", new[] { "IdProduto" });
            DropIndex("dbo.PedidoCliente", new[] { "IdCliente" });
            DropIndex("dbo.Faturamento", new[] { "IdFaturamento" });
            DropTable("dbo.Funcionario");
            DropTable("dbo.Cliente");
            DropTable("dbo.PedidoCliente_Produtos");
            DropTable("dbo.CompraProduto");
            DropTable("dbo.FornecedorProduto");
            DropTable("dbo.PedidoItemFornecedor");
            DropTable("dbo.PedidoFornecedor");
            DropTable("dbo.PedidoCliente");
            DropTable("dbo.Pagamento");
            DropTable("dbo.NotaFiscal");
            DropTable("dbo.Faturamento");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Produto");
            DropTable("dbo.Compra");
            DropTable("dbo.Usuario");
        }
    }
}
