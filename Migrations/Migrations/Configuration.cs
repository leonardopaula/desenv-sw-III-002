namespace Migrations
{
    using System;
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
            List<Dominio.Fornecedor> lforn1 = new List<Dominio.Fornecedor>();
            List<Dominio.Fornecedor> lforn2 = new List<Dominio.Fornecedor>();
            lforn1.Add(new Dominio.Fornecedor { Nome = "OAS S.A.", Email = "propina@oas.com.br" });
            lforn1.Add(new Dominio.Fornecedor { Nome = "Odebrecht", Email = "comercial@cx2.com.br" });
            context.Fornecedor.AddOrUpdate(lforn1[0]);
            context.Fornecedor.AddOrUpdate(lforn1[1]);

            lforn2.Add(new Dominio.Fornecedor { Nome = "ANDRADE GUTIERREZ", Email = "c2@ag.com.br" });
            lforn2.Add(new Dominio.Fornecedor { Nome = "UTC", Email = "utc@utc.com.br" });
            context.Fornecedor.AddOrUpdate(lforn2[0]);
            context.Fornecedor.AddOrUpdate(lforn2[1]);

            var prod = new Dominio.Produto { Nome = "Camiseta", QuantidadeEmEstoque = 2, QuantidadeEstoqueMinimo = 1, Referencia = "CI001", Peso = 20.0f, Fornecedores = lforn1 };
            context.Produto.AddOrUpdate(
                new Dominio.Produto { Nome = "Jaqueta", QuantidadeEmEstoque = 2, QuantidadeEstoqueMinimo = 5, Referencia = "CI002", Peso = 100.0f, Fornecedores = lforn1 },
                new Dominio.Produto { Nome = "Iphone 5s", QuantidadeEmEstoque = 5, QuantidadeEstoqueMinimo = 10, Referencia = "CI003", Peso = 1500.0f, Fornecedores = lforn1 },
                new Dominio.Produto { Nome = "Mega Drive III", QuantidadeEmEstoque = 10, QuantidadeEstoqueMinimo = 20, Referencia = "CI004", Peso = 1000.0f, Fornecedores = lforn2 },
                prod
            );

            List<Dominio.PedidoItemFornecedor> pi = new List<Dominio.PedidoItemFornecedor>();
            pi.Add(new Dominio.PedidoItemFornecedor { Fornecedor = lforn1[0], Produto = prod, Quantidade = 100, DataPrevista = DateTime.Now.Date });

            context.Compra.AddOrUpdate(new Dominio.Compra
            {
                Data = DateTime.Now.Date,
                NumeroNF = 952287,
                Pedidos = pi,
                Status = Dominio.Enums.StatusCompra.AguardandoRecebimento
            });

            try
            {
                context.SaveChanges();
            }catch(System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string mensagem = string.Empty;
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        mensagem += String.Format( "Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw new Exception(mensagem);
            }

            
        }
    }
}
