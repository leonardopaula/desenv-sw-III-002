using Dominio;
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
            return View(carrinho);
        }
    }
}