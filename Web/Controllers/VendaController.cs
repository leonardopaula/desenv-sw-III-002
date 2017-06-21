using Dominio;
using Infraestrutura.Cadastros;
using Infraestrutura.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class VendaController : Controller
    {
        private ProdutoCadastro produtoCadastro;

        public VendaController()
        {
            produtoCadastro = new ProdutoCadastro();
        }

        // GET: Venda
        public ActionResult Index()
        {
            ViewBag.Produtos = produtoCadastro.BuscarTodosComEstoque();

            return View();
        }

        public PartialViewResult CarregarInfoProduto(long idProduto)
        {
            Produto p = produtoCadastro.BuscarPeloId(idProduto);

            List<Produto> carrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            p.QuantidadeEmEstoque -= (carrinho.Count(x => x.IdProduto == p.IdProduto));

            return PartialView("_DetalheProduto", p);
        }

        [HttpPost]
        public JsonResult ComprarProduto(long idProduto)
        {
            Produto produto = produtoCadastro.BuscarPeloId(idProduto);

            List<Produto> produtosCarrinho = Session["Carrinho"] as List<Produto> ?? new List<Produto>();

            produto.QuantidadeEmEstoque -= (produtosCarrinho.Count(x => x.IdProduto == produto.IdProduto));

            bool sucesso = true;
            string message = string.Empty;

            if (produto.QuantidadeEmEstoque == 0)
            {
                sucesso = false;
                message = "Produto indisponível";
            }
            else
            {
                try
                {
                    produtosCarrinho.Add(produto);
                    Session["Carrinho"] = produtosCarrinho;
                    message = "Produto adicionado ao carrinho";
                }
                catch
                {
                    message = "Erro ao adicionar o produto ao carrinho";
                    sucesso = false;
                }
            }


            return Json(new { Sucesso = sucesso, Message = message });
        }
    }
}