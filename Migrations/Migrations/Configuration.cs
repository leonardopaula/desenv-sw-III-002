namespace Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Infraestrutura.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infraestrutura.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Dominio.Fornecedor> lfornecedores = new List<Dominio.Fornecedor>();
            lfornecedores.Add(new Dominio.Fornecedor { IdFornecedor = 1, Nome = "Picareta", Email = "clube@picaretas.com.br" });
            lfornecedores.Add(new Dominio.Fornecedor { IdFornecedor = 2, Nome = "Odebrecht", Email = "comercial@cx2.com.br" });
            context.Fornecedor.AddOrUpdate(lfornecedores[0]);
            context.Fornecedor.AddOrUpdate(lfornecedores[1]);
            context.SaveChanges();

            context.Produto.AddOrUpdate(
                p => p.Nome,
                new Dominio.Produto { IdProduto = 1, Nome = "Camiseta", QuantidadeEmEstoque = 2, QuantidadeEstoqueMinimo = 5, Fornecedores = lfornecedores },
                new Dominio.Produto { IdProduto = 2, Nome = "Blusa", QuantidadeEmEstoque = 0, QuantidadeEstoqueMinimo = 1, Fornecedores = lfornecedores });
            context.SaveChanges();
        }
    }
}
