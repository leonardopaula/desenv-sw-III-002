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
            var p = cc.BuscarProdutosEstoqueBaixo();

            return View(p);
        }
    }
}