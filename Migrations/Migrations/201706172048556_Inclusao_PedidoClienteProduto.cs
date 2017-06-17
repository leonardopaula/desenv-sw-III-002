namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inclusao_PedidoClienteProduto : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PedidoCliente_Produtos", newName: "PedidoClienteProduto");
            DropForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento");
            DropIndex("dbo.Faturamento", new[] { "IdFaturamento" });
            DropIndex("dbo.NotaFiscal", new[] { "IdNotaFiscal" });
            DropPrimaryKey("dbo.Cliente");
            DropPrimaryKey("dbo.Funcionario");
            DropPrimaryKey("dbo.Usuario");
            DropPrimaryKey("dbo.Faturamento");
            DropPrimaryKey("dbo.NotaFiscal");
            DropPrimaryKey("dbo.PedidoClienteProduto");
            AddColumn("dbo.PedidoClienteProduto", "IdPedidoClienteProduto", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.PedidoClienteProduto", "Quantidade", c => c.Int(nullable: false));
            AlterColumn("dbo.Cliente", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Funcionario", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Usuario", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Faturamento", "IdFaturamento", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.NotaFiscal", "IdNotaFiscal", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cliente", "Id");
            AddPrimaryKey("dbo.Funcionario", "Id");
            AddPrimaryKey("dbo.Usuario", "Id");
            AddPrimaryKey("dbo.Faturamento", "IdFaturamento");
            AddPrimaryKey("dbo.NotaFiscal", "IdNotaFiscal");
            AddPrimaryKey("dbo.PedidoClienteProduto", "IdPedidoClienteProduto");
            CreateIndex("dbo.Faturamento", "IdFaturamento");
            CreateIndex("dbo.NotaFiscal", "IdNotaFiscal");
            AddForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente", "Id");
            AddForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento", "IdFaturamento");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento");
            DropForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.NotaFiscal", new[] { "IdNotaFiscal" });
            DropIndex("dbo.Faturamento", new[] { "IdFaturamento" });
            DropPrimaryKey("dbo.PedidoClienteProduto");
            DropPrimaryKey("dbo.NotaFiscal");
            DropPrimaryKey("dbo.Faturamento");
            DropPrimaryKey("dbo.Usuario");
            DropPrimaryKey("dbo.Funcionario");
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.NotaFiscal", "IdNotaFiscal", c => c.Long(nullable: false));
            AlterColumn("dbo.Faturamento", "IdFaturamento", c => c.Long(nullable: false));
            AlterColumn("dbo.Usuario", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Funcionario", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Cliente", "Id", c => c.Long(nullable: false));
            DropColumn("dbo.PedidoClienteProduto", "Quantidade");
            DropColumn("dbo.PedidoClienteProduto", "IdPedidoClienteProduto");
            AddPrimaryKey("dbo.PedidoClienteProduto", new[] { "IdPedidoCliente", "IdProduto" });
            AddPrimaryKey("dbo.NotaFiscal", "IdNotaFiscal");
            AddPrimaryKey("dbo.Faturamento", "IdFaturamento");
            AddPrimaryKey("dbo.Usuario", "Id");
            AddPrimaryKey("dbo.Funcionario", "Id");
            AddPrimaryKey("dbo.Cliente", "Id");
            CreateIndex("dbo.NotaFiscal", "IdNotaFiscal");
            CreateIndex("dbo.Faturamento", "IdFaturamento");
            AddForeignKey("dbo.NotaFiscal", "IdNotaFiscal", "dbo.Faturamento", "IdFaturamento");
            AddForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente", "Id");
            RenameTable(name: "dbo.PedidoClienteProduto", newName: "PedidoCliente_Produtos");
        }
    }
}
