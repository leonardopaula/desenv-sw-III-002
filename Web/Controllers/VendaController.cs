using Infraestrutura.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ComprarProduto()
        {
            bool sucesso = true;
            string message = "Produto em falta";
            try
            {
                //Verifica estoque
                EmailService es = new EmailService();
                es.SendEmail(new List<string> { "mukatk@gmail.com" }, "Produto em falta", "O produto blablabla está em falta no estoque. Por favor, reponha imediatamente");
            }
            catch
            {
                sucesso = false;
            }

            return Json(new { Sucesso = sucesso, Message = message });
        }
    }
}