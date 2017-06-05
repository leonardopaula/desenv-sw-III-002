using Dominio;
using Dominio.Dinamico;
using Infraestrutura.Util;
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

        [HttpPost]
        public JsonResult CalculaPrazo()
        {
            CorreiosService service = new CorreiosService("40010", "9586000", "1");

            var frete = service.CalculaPrecoPrazo().Servicos.Select(x => new
            {
                preco = x.Valor,
                prazo = x.PrazoEntrega
            });

            return Json(frete);
        }
    }
}