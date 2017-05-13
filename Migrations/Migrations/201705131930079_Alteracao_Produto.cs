namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Produto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Preco", c => c.Single(nullable: false));
            AddColumn("dbo.Produto", "UrlImagem", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "UrlImagem");
            DropColumn("dbo.Produto", "Preco");
        }
    }
}
