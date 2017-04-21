using System.Web.Mvc;
using Infraestrutura.Cadastros;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
                                Fornecedor = forn,
                                IdFornecedor = forn.IdFornecedor,
                                Produto = prod,
                                IdProduto = prod.IdProduto,
                                Quantidade = int.Parse(qtde),
                                DataPrevista = retornoServico.DataEnvio.Value
                            });
                        }
                        else
                        {
                            // Exibe mensagem retornada pelo serviço 
                            // Volta a modal de escolha de fornecedor para alterar o fornecedor e/ou quantidade
                        }
                        
                    }
                }
            }

            Dominio.Compra c =
                new Dominio.Compra {
                    Pedidos = pi,
                    NumeroNF = 123123,
                    Data = DateTime.Now,
                    Status = Dominio.Enums.StatusCompra.AguardandoRecebimento // Vem do serviço
                };
            cc.Adicionar(c);

            return View();
        }
    }
}