using System.Web.Mvc;
using Infraestrutura.Cadastros;
using Newtonsoft.Json;

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
    }
}