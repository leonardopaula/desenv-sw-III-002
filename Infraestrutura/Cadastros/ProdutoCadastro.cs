using Dominio;
using Dominio.Dinamico;
using Infraestrutura.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class ProdutoCadastro
    {
        private EFContext contexto;
        public ProdutoCadastro()
        {
            contexto = new EFContext();
        }

        public Produto BuscarPeloId(long IdProduto)
        {
            IQueryable<Produto> prod = from produto in contexto.Produto
                                       where produto.IdProduto == IdProduto
                                      select produto;
            return prod.FirstOrDefault();
        }

        public List<Produto> BuscarTodos()
        {
            IQueryable<Produto> clientes = from cliente in contexto.Produto
                                           select cliente;
            return clientes.ToList();
        }

        public List<Produto> BuscarTodosComEstoque()
        {
            IQueryable<Produto> produtos = from p in contexto.Produto
                                           where p.QuantidadeEmEstoque > 0
                                           select p;
            return produtos.ToList();
        }

        public FinalizarPedidoRetorno FinalizarPedido(List<Produto> carrinho)
        {
            FinalizarPedidoRetorno resultadoFinalizacao = new FinalizarPedidoRetorno();


            return resultadoFinalizacao;
        }

        public bool ValidaQuantidade(long idProduto, int count)
        {
            return (from p in contexto.Produto where p.IdProduto == idProduto && ((p.QuantidadeEmEstoque - count) >= 0) select p).Any();
        }

        public bool ValidaQuantidadeEstoque(List<Produto> carrinho)
        {
            List<ProdutoCarrinho> carrinhoGroup = carrinho
                .GroupBy(x => x.IdProduto)
                .Select(x => new ProdutoCarrinho
                {
                    Quantidade = x.Count(),
                    Produto = x.FirstOrDefault()
                }).ToList();


            bool quantidadeValida = true;

            foreach (ProdutoCarrinho item in carrinhoGroup)
            {
                if (!ValidaQuantidade(item.Produto.IdProduto, item.Quantidade))
                {
                    quantidadeValida = false;
                    break;
                }
            }

            return quantidadeValida;
        }

        public void RealizaVenda(PedidoCliente pedidoCliente, DadosPedido dadosPedido)
        {
            using (var transaction = contexto.Database.BeginTransaction())
            {
                try
                {
                    EmailService emailService = new EmailService();

                    pedidoCliente.CodigoRastreio = "4WEB" + (new Random().Next(0, 1000000)).ToString().PadLeft(8, '0');

                    pedidoCliente.Numero = (new Random().Next(0, 1000000));

                    foreach (var item in pedidoCliente.Produtos)
                    {
                        item.IdProduto = item.Produto.IdProduto;
                        Produto p = contexto.Produto.FirstOrDefault(x => x.IdProduto == item.IdProduto);
                        p.QuantidadeEmEstoque -= item.Quantidade;
                        contexto.Entry(p).State = System.Data.Entity.EntityState.Modified;

                        if (p.QuantidadeEmEstoque < p.QuantidadeEstoqueMinimo)
                        {
                            try
                            {
                                string email = ConfigurationManager.AppSettings["emailResponsavel"]?.ToString();
                                emailService.SendEmail(new List<string> { email }, "Produto em falta", $"O produto {p.Nome} encontra-se com baixa quantidade em estoque. Repor imediatamente.");
                            } catch { }
                        }

                        item.Produto = null;
                    }

                    contexto.PedidoCliente.Add(pedidoCliente);
                    contexto.SaveChanges();

                    Faturamento faturamento = new Faturamento();
                    Pagamento pagamento = new Pagamento();
                    pagamento.Data = DateTime.Now;
                    pagamento.MeioPagamento = (Dominio.Enums.MeioPagamento)dadosPedido.MeioPagamento;
                    pagamento.Origem = pedidoCliente.IdCliente;
                    contexto.Pagamento.Add(pagamento);
                    contexto.SaveChanges();

                    faturamento.Pagamento = pagamento;
                    faturamento.PedidoCliente = pedidoCliente;
                    contexto.Faturamento.Add(faturamento);
                    contexto.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
