namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_MapeamentoClienteFuncionario : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Usuario");
            DropForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente");
            DropPrimaryKey("dbo.Cliente");
            DropPrimaryKey("dbo.Funcionario");
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Cliente", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Funcionario", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Cliente", "Id");
            AddPrimaryKey("dbo.Funcionario", "Id");
            CreateIndex("dbo.Cliente", "Id");
            CreateIndex("dbo.Funcionario", "Id");
            AddForeignKey("dbo.Cliente", "Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Funcionario", "Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente", "Id");
            DropColumn("dbo.Cliente", "Nome");
            DropColumn("dbo.Cliente", "Login");
            DropColumn("dbo.Cliente", "Senha");
            DropColumn("dbo.Cliente", "Email");
            DropColumn("dbo.Funcionario", "Nome");
            DropColumn("dbo.Funcionario", "Login");
            DropColumn("dbo.Funcionario", "Senha");
            DropColumn("dbo.Funcionario", "Email");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Funcionario", "Email", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AddColumn("dbo.Funcionario", "Senha", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AddColumn("dbo.Funcionario", "Login", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Funcionario", "Nome", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AddColumn("dbo.Cliente", "Email", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AddColumn("dbo.Cliente", "Senha", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AddColumn("dbo.Cliente", "Login", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.Cliente", "Nome", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Funcionario", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Cliente", "Id", "dbo.Usuario");
            DropIndex("dbo.Funcionario", new[] { "Id" });
            DropIndex("dbo.Cliente", new[] { "Id" });
            DropPrimaryKey("dbo.Funcionario");
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.Funcionario", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Cliente", "Id", c => c.Long(nullable: false, identity: true));
            
            AddPrimaryKey("dbo.Funcionario", "Id");
            AddPrimaryKey("dbo.Cliente", "Id");
            AddForeignKey("dbo.PedidoCliente", "IdCliente", "dbo.Cliente", "Id");
        }
    }
}
