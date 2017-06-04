using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Infraestrutura.Cadastros;

namespace Web.Controllers
{
    public class FaturamentoController : Controller
    {
        private FaturamentoCadastro fc = new FaturamentoCadastro();

        // GET: Faturamento
        public ActionResult Index()
        {
            ViewBag.Pedidos = fc.pedidosPendentesEnvio();

            return View();
        }
    }
}