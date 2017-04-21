using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Infraestrutura.Util.FornecedorService servico = new Infraestrutura.Util.FornecedorService();
            var disp = servico.ObterDisponibilidadeDeProduto("123", 2);
            return View();
        }
    }
}