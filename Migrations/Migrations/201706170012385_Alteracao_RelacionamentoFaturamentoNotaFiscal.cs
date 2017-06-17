namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_RelacionamentoFaturamentoNotaFiscal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.NotaFiscal");
            AddColumn("dbo.NotaFiscal", "IdFaturamento", c => c.Long(nullable: false));
            AlterColumn("dbo.Faturamento", "IdNotaFiscal", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturamento", "IdNotaFiscal", c => c.Long(nullable: false));
            DropColumn("dbo.NotaFiscal", "IdFaturamento");
            AddForeignKey("dbo.Faturamento", "IdFaturamento", "dbo.NotaFiscal", "IdNotaFiscal");
        }
    }
}
