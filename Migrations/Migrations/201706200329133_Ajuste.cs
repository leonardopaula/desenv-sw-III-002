namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.Pagamento");
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.PedidoCliente");
            DropIndex("dbo.Faturamento", new[] { "IdFaturamento" });
            AddColumn("dbo.Faturamento", "PagamentoId", c => c.Long(nullable: false));
            AddColumn("dbo.Faturamento", "PedidoClienteId", c => c.Long(nullable: false));
            CreateIndex("dbo.Faturamento", "PagamentoId");
            CreateIndex("dbo.Faturamento", "PedidoClienteId");
            AddForeignKey("dbo.Faturamento", "PagamentoId", "dbo.Pagamento", "IdPagamento");
            AddForeignKey("dbo.Faturamento", "PedidoClienteId", "dbo.PedidoCliente", "IdPedidoCliente");
            DropColumn("dbo.Faturamento", "IdPedidoCliente");
            DropColumn("dbo.Faturamento", "IdPagamento");
            DropColumn("dbo.Faturamento", "IdNotaFiscal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faturamento", "IdNotaFiscal", c => c.Long());
            AddColumn("dbo.Faturamento", "IdPagamento", c => c.Long(nullable: false));
            AddColumn("dbo.Faturamento", "IdPedidoCliente", c => c.Long(nullable: false));
            DropForeignKey("dbo.Faturamento", "PedidoClienteId", "dbo.PedidoCliente");
            DropForeignKey("dbo.Faturamento", "PagamentoId", "dbo.Pagamento");
            DropIndex("dbo.Faturamento", new[] { "PedidoClienteId" });
            DropIndex("dbo.Faturamento", new[] { "PagamentoId" });
            DropColumn("dbo.Faturamento", "PedidoClienteId");
            DropColumn("dbo.Faturamento", "PagamentoId");
            CreateIndex("dbo.Faturamento", "IdFaturamento");
            AddForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.PedidoCliente", "IdPedidoCliente");
            AddForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.Pagamento", "IdPagamento");
        }
    }
}
