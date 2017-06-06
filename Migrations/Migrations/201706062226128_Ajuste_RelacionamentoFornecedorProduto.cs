namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_RelacionamentoFornecedorProduto : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FornecedorProduto", name: "IdProduto", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FornecedorProduto", name: "IdFornecedor", newName: "IdProduto");
            RenameColumn(table: "dbo.FornecedorProduto", name: "__mig_tmp__0", newName: "IdFornecedor");
            RenameIndex(table: "dbo.FornecedorProduto", name: "IX_IdProduto", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.FornecedorProduto", name: "IX_IdFornecedor", newName: "IX_IdProduto");
            RenameIndex(table: "dbo.FornecedorProduto", name: "__mig_tmp__0", newName: "IX_IdFornecedor");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FornecedorProduto", name: "IX_IdFornecedor", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.FornecedorProduto", name: "IX_IdProduto", newName: "IX_IdFornecedor");
            RenameIndex(table: "dbo.FornecedorProduto", name: "__mig_tmp__0", newName: "IX_IdProduto");
            RenameColumn(table: "dbo.FornecedorProduto", name: "IdFornecedor", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FornecedorProduto", name: "IdProduto", newName: "IdFornecedor");
            RenameColumn(table: "dbo.FornecedorProduto", name: "__mig_tmp__0", newName: "IdProduto");
        }
    }
}
