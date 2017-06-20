namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_Relacionamento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento");
            DropIndex("dbo.NotaFiscal", new[] { "IdNotaFiscal" });
            AddColumn("dbo.NotaFiscal", "FaturamentoId", c => c.Long(nullable: false));
            CreateIndex("dbo.NotaFiscal", "FaturamentoId");
            AddForeignKey("dbo.NotaFiscal", "FaturamentoId", "dbo.Faturamento", "IdFaturamento");
            DropColumn("dbo.NotaFiscal", "IdFaturamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NotaFiscal", "IdFaturamento", c => c.Long(nullable: false));
            DropForeignKey("dbo.NotaFiscal", "FaturamentoId", "dbo.Faturamento");
            DropIndex("dbo.NotaFiscal", new[] { "FaturamentoId" });
            DropColumn("dbo.NotaFiscal", "FaturamentoId");
            CreateIndex("dbo.NotaFiscal", "IdNotaFiscal");
            AddForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento", "IdFaturamento");
        }
    }
}
