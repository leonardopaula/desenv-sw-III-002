namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inclusao_EnderecoAPedidoCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IdEndereco = c.Long(nullable: false, identity: true),
                        Rua = c.String(maxLength: 150, unicode: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 150, unicode: false),
                        IdCidade = c.Long(nullable: false),
                        CEP = c.Long(nullable: false),
                        Complemento = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.Cidade", t => t.IdCidade)
                .Index(t => t.IdCidade);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        IdCidade = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        CEP = c.Long(nullable: false),
                        IdEstado = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdCidade)
                .ForeignKey("dbo.Estado", t => t.IdEstado)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        IdEstado = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        UF = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            AddColumn("dbo.PedidoCliente", "IdEnderecoEntrega", c => c.Long(nullable: false));
            CreateIndex("dbo.PedidoCliente", "IdEnderecoEntrega");
            AddForeignKey("dbo.PedidoCliente", "IdEnderecoEntrega", "dbo.Endereco", "IdEndereco");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoCliente", "IdEnderecoEntrega", "dbo.Endereco");
            DropForeignKey("dbo.Endereco", "IdCidade", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "IdEstado", "dbo.Estado");
            DropIndex("dbo.Cidade", new[] { "IdEstado" });
            DropIndex("dbo.Endereco", new[] { "IdCidade" });
            DropIndex("dbo.PedidoCliente", new[] { "IdEnderecoEntrega" });
            DropColumn("dbo.PedidoCliente", "IdEnderecoEntrega");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Endereco");
        }
    }
}
