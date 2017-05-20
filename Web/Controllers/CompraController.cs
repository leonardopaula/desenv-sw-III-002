using System.Web.Mvc;
using Infraestrutura.Cadastros;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Dominio;

namespace Web.Controllers
{
    public class CompraController : Controller
    {
        private CompraCadastro cc  = new CompraCadastro();
        private ProdutoCadastro pc = new ProdutoCadastro();
        private FornecedorCadastro fc = new FornecedorCadastro();

        // GET: Compra
        public ActionResult Index()
        {
            ViewBag.produtos = cc.BuscarProdutosEstoqueBaixo();

            return View();
        }

        public ActionResult GetProductInfo(string IdProduto)
        {
            var prod = cc.BuscarDetalhesProduto(int.Parse(IdProduto));
            var json = JsonConvert.SerializeObject(prod, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return Content(json, "application/json");
        }

        public ActionResult Salva()
        {
            List<Dominio.PedidoItemFornecedor> pi = new List<Dominio.PedidoItemFornecedor>();

            // Recebe os parâmetros do formulário e trata
            var form = Request.Form.AllKeys;

            string field = "", value = "", produto = "", qtde = "";
            var prod = new Dominio.Produto();
            var forn = new Dominio.Fornecedor();
            List<Infraestrutura.FornecedorServiceRef.RetornoRequisicao> erros =
                new List<Infraestrutura.FornecedorServiceRef.RetornoRequisicao>();

            foreach (string key in form)
            {
                // Campo name do form
                field = key;

                // Valor do form
                value = Request.Form[field];

                // Limita a busca para fornecedores
                if (field.IndexOf("forn_") == 0)
                {
                    // Caso esteja populado:
                    if (value != "")
                    {
                        // produto
                        produto = field.Replace("forn_", "");
                        qtde = Request.Form["qtde_"+produto];
                        prod = pc.BuscarPeloId(long.Parse(produto));
                        forn = fc.BuscarPeloId(long.Parse(value));

                        var servicoFornecedor = new Infraestrutura.FornecedorServiceRef.ServiceFornecedorClient();
                        var retornoServico = servicoFornecedor.ObterDisponibilidadeProduto(
                            new Infraestrutura.FornecedorServiceRef.ProdutoConsultado()
                            {
                                QuantidadeRequerida = int.Parse(qtde),
                                Referencia = prod.Referencia
                            });

                        if (retornoServico.DataEnvio.HasValue)
                        {
                            pi.Add(new Dominio.PedidoItemFornecedor
                            {
                                //Fornecedor = forn,
                                IdFornecedor = forn.IdFornecedor,
                                //Produto = prod,
                                IdProduto = prod.IdProduto,
                                Quantidade = int.Parse(qtde),
                                DataPrevista = retornoServico.DataEnvio.Value
                            });
                        }
                        else
                        {
                            // Exibe mensagem retornada pelo serviço caso ocorra erro
                            erros.Add(retornoServico);
                        }
                    }
                }
            }

            if (erros.Count == 0)
            {
                Dominio.Compra c =
                    new Dominio.Compra
                    {
                        Pedidos = pi,
                        NumeroNF = new Random().Next(1, 1000000 + 1),
                        Data = DateTime.Now,
                        Status = Dominio.Enums.StatusCompra.AguardandoRecebimento // Vem do serviço
                };
                cc.Adicionar(c);
                var json = JsonConvert.SerializeObject(c, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                return Content(json, "application/json");
            } else
            {
                var json = JsonConvert.SerializeObject(erros, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                return Content(json, "application/json");
            }
        }

        // GET: Relatorio
        public ActionResult Relatorio(string IdCompra)
        {
            ViewBag.compra = cc.BuscarCompra(int.Parse(IdCompra));

            return View();
        }

        public ActionResult ListagemNaoRecebidas()
        {
            ViewBag.compras = cc.BuscarTodosAguardandoRecebimento();
            return View();
        }

        public ActionResult ConfirmarRecebimento(string idCompra)
        {
            cc.ConfirmarRecebimento(long.Parse(idCompra));
            ViewBag.compras = cc.BuscarTodosAguardandoRecebimento();
            return View("ListagemNaoRecebidas");
        }

        public ActionResult ReceberNotaFiscal(string idCompra)
        {
            ViewBag.compra = cc.BuscarCompra(long.Parse(idCompra));
            return View("RecebimentoNF");
        }

        public ActionResult GetProdutosDaCompra(string idCompra)
        {
            var compra = cc.BuscarCompra(long.Parse(idCompra));

            List<Produto> produtos = new List<Produto>();
            foreach (var pedido in compra.Pedidos)
            {
                produtos.Add(pedido.Produto);
            }

            var json = JsonConvert.SerializeObject(produtos, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return Content(json, "application/json");
        }

        public ActionResult InformarDivergencia(string idCompra, string produto, string quantidadeEsperada, string quantidadeRecebida)
        {
            Dominio.ExcecaoNF excecao = new Dominio.ExcecaoNF();

            excecao.Compra = cc.BuscarCompra(long.Parse(idCompra));
            excecao.IdCompra = long.Parse(idCompra);
            excecao.QuantidadeAguardada = int.Parse(quantidadeEsperada);
            excecao.QuantidadeRecebida = int.Parse(quantidadeRecebida);
            excecao.IdPedidoItemFornecedor = 0;
                var json = JsonConvert.SerializeObject("", Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                return Content(json, "application/json");
            
        }
    }

}