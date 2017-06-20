using Dominio;
using Dominio.Dinamico;
using Infraestrutura.Util;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using Infraestrutura.Cadastros;
using System.Globalization;

namespace Web.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            List<ProdutoCarrinho> carrinhoGroup = carrinho
                .GroupBy(x => x.IdProduto)
                .Select(x => new ProdutoCarrinho
                {
                    Quantidade = x.Count(),
                    Produto = x.FirstOrDefault()
                }).ToList();

            return View(carrinhoGroup);
        }

        public void RemoverProdutos(int idProduto)
        {
            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            carrinho = carrinho.Where(x => x.IdProduto != idProduto).ToList();

            Session["Carrinho"] = carrinho;
        }

        public ActionResult DadosCliente()
        {
            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            if (carrinho.Count == 0)
            {
                return RedirectToAction("Index", "Venda");
            }
            else if (carrinho.Count > 0 && Session["Cliente"] != null)
            {
                return RedirectToAction("Pedido");
            }

            return View();
        }

        public ActionResult Pedido()
        {
            return View();
        }

        public ActionResult Resumo()
        {
            PedidoCliente pedido = Session["PedidoCliente"] as PedidoCliente;
            float valorFrete = float.Parse(Session["ValorFrete"].ToString());

            float somaPedido = pedido.Produtos.Sum(x => x.Quantidade * x.Produto.Preco);

            ViewBag.ValorTotalPedido = valorFrete + somaPedido;

            return View(pedido);
        }

        [HttpPost]
        public JsonResult CalculaPrazo(string cdServico, string cepDestino)
        {
            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            int pesoTotal = (int)Math.Round(((carrinho.Sum(x => x.Preco)) / 1000));

            CorreiosService service = new CorreiosService(cdServico, cepDestino, pesoTotal.ToString());

            var frete = service.CalculaPrecoPrazo().Servicos.Select(x => new
            {
                preco = x.Valor,
                prazo = x.PrazoEntrega
            });

            return Json(frete);
        }

        public JsonResult BuscaCidades(string prefix)
        {
            CidadeCadastro cidadeNeg = new CidadeCadastro();

            var cidades = cidadeNeg.BuscaCidades(prefix);

            return Json(cidades, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FinalizarPedido(DadosPedido pedido)
        {
            Cliente cliente = Session["Cliente"] as Cliente;

            Endereco enderecoEntrega = new Endereco();
            enderecoEntrega.Rua = pedido.Endereco;
            enderecoEntrega.CEP = Convert.ToInt64(pedido.CEP);
            enderecoEntrega.Numero = pedido.Numero;
            enderecoEntrega.Bairro = pedido.Bairro;

            Session["ValorFrete"] = pedido.ValorFrete;
            Session["DadosPedido"] = pedido;

            CidadeCadastro cidadeNeg = new CidadeCadastro();

            Cidade cidade = cidadeNeg.BuscaCidade(pedido.Cidade);

            if (cidade == null)
            {
                return Json(new { CodRetorno = "aviso", Mensagem = "Cidade não encontrada" });
            }
            else
            {
                enderecoEntrega.Cidade = cidade;
            }
            
            enderecoEntrega.Complemento = pedido.Complemento;

            PedidoCliente pedidoCliente = new PedidoCliente
            {
                Data = DateTime.Now,
                EnderecoEntrega = enderecoEntrega,
                IdCliente = cliente.Id,
                Status = Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento
            };

            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            ProdutoCadastro produtoNeg = new ProdutoCadastro();

            if (produtoNeg.ValidaQuantidadeEstoque(carrinho))
            {
                var produtos = carrinho
                .GroupBy(x => x.IdProduto)
                .Select(x => new PedidoClienteProduto
                {
                    Produto = x.FirstOrDefault(),
                    Quantidade = x.Count()
                }).ToList();

                pedidoCliente.Produtos = produtos;

                Session["PedidoCliente"] = pedidoCliente;

                return Json(new { CodRetorno = "sucesso", Mensagem = "Você será redirecionado para conclusão do pedido" });
            }
            else
            {
                Session["Carrinho"] = null;
                Session["DadosPedido"] = null;
                Session["PedidoCliente"] = null;
                return Json(new { CodRetorno = "erro", Mensagem = "Os produtos não estão mais disponíveis" });
            }
        }

        [HttpPost]
        public void ConfirmarCompra()
        {
            ProdutoCadastro produtoNeg = new ProdutoCadastro();

            DadosPedido dadosPedido = Session["DadosPedido"] as DadosPedido;
            PedidoCliente pedidoCliente = Session["PedidoCliente"] as PedidoCliente;

            produtoNeg.RealizaVenda(pedidoCliente, dadosPedido);
        }
    }
}