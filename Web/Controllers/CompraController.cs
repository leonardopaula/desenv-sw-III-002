using System.Web.Mvc;
using Infraestrutura.Cadastros;

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

        public JsonResult GetProductInfo(string IdProduto)
        {
            return Json(cc.BuscarDetalhesProduto(int.Parse(IdProduto)), JsonRequestBehavior.AllowGet);
        }
    }
}