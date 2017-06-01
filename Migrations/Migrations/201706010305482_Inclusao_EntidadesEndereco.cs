namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class Inclusao_EntidadesEndereco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Endereco", "Rua", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Endereco", "Bairro", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Cidade", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Estado", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Estado", "UF", c => c.String(nullable: false, maxLength: 150, unicode: false));
            DropColumn("dbo.Cidade", "CEP");
            var arquivos = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "../../Arquivos/");
            foreach (var arquivo in arquivos)
            {
                SqlFile(arquivo);
            }

        }

        public override void Down()
        {
            Sql("DELETE FROM Cidade");
            Sql("DELETE FROM Estado");
            AddColumn("dbo.Cidade", "CEP", c => c.Long(nullable: false));
            AlterColumn("dbo.Estado", "UF", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Estado", "Nome", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Cidade", "Nome", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Endereco", "Bairro", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Endereco", "Rua", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
