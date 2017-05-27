using Dominio;
using Dominio.Dinamico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}