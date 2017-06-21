namespace Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infraestrutura.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            CommandTimeout = Int32.MaxValue; // PC do milhão
        }

        protected override void Seed(Infraestrutura.EFContext context)
        {
            List<Dominio.Fornecedor> lforn1 = new List<Dominio.Fornecedor>();
            List<Dominio.Fornecedor> lforn2 = new List<Dominio.Fornecedor>();


            Dominio.Fornecedor umbro = new Dominio.Fornecedor { Nome = "Umbro", Email = "comercial@umbro.com.br" };
            Dominio.Fornecedor nike = new Dominio.Fornecedor { Nome = "Nike", Email = "comercial@nike.com.br" };
            Dominio.Fornecedor apple = new Dominio.Fornecedor { Nome = "Apple", Email = "sales@apple.com.br" };
            Dominio.Fornecedor samsung = new Dominio.Fornecedor { Nome = "Samsung", Email = "sales@samsung.com.br" };

            List<Dominio.Fornecedor> lforn3 = new List<Dominio.Fornecedor>() { apple };

            lforn1.Add(umbro);
            lforn1.Add(nike);
            lforn1.Add(new Dominio.Fornecedor { Nome = "Odebrecht", Email = "comercial@cx2.com.br" });
            context.Fornecedor.AddOrUpdate(lforn1[0]);
            context.Fornecedor.AddOrUpdate(lforn1[1]);

            lforn2.Add(new Dominio.Fornecedor { Nome = "ANDRADE GUTIERREZ", Email = "c2@ag.com.br" });
            lforn2.Add(new Dominio.Fornecedor { Nome = "UTC", Email = "utc@utc.com.br" });
            context.Fornecedor.AddOrUpdate(lforn2[0]);
            context.Fornecedor.AddOrUpdate(lforn2[1]);

            var prod = new Dominio.Produto
            {
                Nome = "Camiseta",
                QuantidadeEmEstoque = 2,
                Preco = 199.0f,
                UrlImagem = "~/Images/Produtos/camiseta tabajara.jpg",
                QuantidadeEstoqueMinimo = 1,
                Referencia = "CI001",
                Peso = 1.0f,
                Fornecedores = lforn1
            };
            var prodChape = new Dominio.Produto
            {
                Nome = "Camiseta Chape",
                QuantidadeEmEstoque = 2,
                Preco = 199.0f,
                UrlImagem = "~/Images/Produtos/chapecoense.jpg",
                QuantidadeEstoqueMinimo = 1,
                Referencia = "CI002",
                Peso = 1.0f,
                Fornecedores = new List<Dominio.Fornecedor>() { umbro }
            };
            context.Produto.AddOrUpdate(
                new Dominio.Produto { Nome = "Jaqueta", QuantidadeEmEstoque = 2, Preco = 329.99f, UrlImagem = "~/Images/Produtos/Jaqueta.png", QuantidadeEstoqueMinimo = 5, Referencia = "CI005", Peso = 100.0f, Fornecedores = lforn1 },
                new Dominio.Produto { Nome = "Iphone 5s", QuantidadeEmEstoque = 5, Preco = 2000.0f, UrlImagem = "~/Images/Produtos/iphone.png", QuantidadeEstoqueMinimo = 10, Referencia = "CI003", Peso = 1500.0f, Fornecedores = lforn3 },
                new Dominio.Produto { Nome = "Mega Drive III", QuantidadeEmEstoque = 10, Preco = 459.0f, UrlImagem = "~/Images/Produtos/mega-drive.jpg", QuantidadeEstoqueMinimo = 20, Referencia = "CI004", Peso = 1000.0f, Fornecedores = lforn2 },
                new Dominio.Produto { Nome = "Camiseta Grêmio", QuantidadeEmEstoque = 10, Preco = 219.0f, UrlImagem = "~/Images/Produtos/gremio.jpg", QuantidadeEstoqueMinimo = 20, Referencia = "CI006", Peso = 1000.0f, Fornecedores = new List<Dominio.Fornecedor>() { umbro } },
                new Dominio.Produto { Nome = "Camiseta Internacional", QuantidadeEmEstoque = 10, Preco = 159.0f, UrlImagem = "~/Images/Produtos/internacional.jpg", QuantidadeEstoqueMinimo = 20, Referencia = "CI007", Peso = 1000.0f, Fornecedores = new List<Dominio.Fornecedor>() { nike } },
                new Dominio.Produto { Nome = "Samsung Galaxy j5 duos", QuantidadeEmEstoque = 10, Preco = 1459.0f, UrlImagem = "~/Images/Produtos/samsung.jpg", QuantidadeEstoqueMinimo = 20, Referencia = "CI008", Peso = 1000.0f, Fornecedores = new List<Dominio.Fornecedor>() { samsung } },
                prod,
                prodChape
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

            /* Cliente */


            Dominio.Cliente cli2 = new Dominio.Cliente
            {
                Id = 12,
                Cpf = 8381543336,
                Email = "leonardo@gmail.com",
                Login = "LS",
                Nome = "Leonardo dos Santos",
                Rg = 014442,
                Senha = "123l"
            };
            context.Cliente.AddOrUpdate(cli2);

            Dominio.Cidade ci = context.Cidade.Find(1);

            /* Endereço */
            Dominio.Endereco end = new Dominio.Endereco
            {
                CEP = 93115270,
                Bairro = "Santos Dumont",
                Cidade = ci,
                Complemento = "B18 A31",
                Numero = 36,
                Rua = "Tomé de Souza"
            };
            context.Endereco.AddOrUpdate(end);

            var lprod = new List<Dominio.PedidoClienteProduto>();

            var produtoPedido = context.Produto.FirstOrDefault();
            if (produtoPedido != null)
            {
                lprod.Add(new Dominio.PedidoClienteProduto()
                {
                    IdProduto = produtoPedido.IdProduto,
                    Produto = produtoPedido,
                    Quantidade = 1
                });
            }

            var camisetaProd = context.Produto.FirstOrDefault(p => p.Nome == "Camiseta");
            if (camisetaProd != null)
            {
                lprod.Add(new Dominio.PedidoClienteProduto()
                {
                    IdProduto = camisetaProd.IdProduto,
                    Produto = camisetaProd,
                    Quantidade = 1
                });
            }

            /* PedidoCliente */
            Dominio.PedidoCliente pc = new Dominio.PedidoCliente
            {
                Cliente = cli2,
                CodigoRastreio = "AA123456789BR",
                Data = DateTime.Now,
                EnderecoEntrega = end,
                NumDocPag = 1,
                Numero = 234,
                Status = Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento,
                Produtos = lprod
            };
            context.PedidoCliente.AddOrUpdate(pc);



            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string mensagem = string.Empty;
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        mensagem += String.Format("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw new Exception(mensagem);
            }


        }

    }
}
