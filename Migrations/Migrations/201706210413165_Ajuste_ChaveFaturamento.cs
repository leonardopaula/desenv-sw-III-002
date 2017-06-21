namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_ChaveFaturamento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NotaFiscal", "FaturamentoId", "dbo.Faturamento");
            DropTable("Faturamento");
            CreateTable(
                "dbo.Faturamento",
                c => new
                {
                    IdFaturamento = c.Long(nullable: false, identity: true),
                    PagamentoId = c.Long(nullable: false),
                    PedidoClienteId = c.Long(nullable: false)
                })
                .PrimaryKey(t => t.IdFaturamento)
                .ForeignKey("dbo.Pagamento", t => t.PagamentoId)
                .ForeignKey("dbo.PedidoCliente", t => t.PedidoClienteId)
                .Index(t => t.IdFaturamento);
            AddForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento", "IdFaturamento");
        }
        
        public override void Down()
        {
        }
    }
}
