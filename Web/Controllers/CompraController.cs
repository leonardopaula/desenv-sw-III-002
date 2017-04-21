using System.Web.Mvc;
using Infraestrutura.Cadastros;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class CompraController : Controller
    {
        private CompraCadastro cc = new CompraCadastro();

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
            // Recebe os parâmetros do formulário e trata
            var form = Request.Form.AllKeys;

            List<Dominio.PedidoItemFornecedor> pi;
            //pi.Add(new Dominio.PedidoItemFornecedor)

            var pf = new Dominio.PedidoFornecedor();

            var compra = new Dominio.Compra();
            compra.Data = DateTime.Now;

            return View();
        }
    }
}