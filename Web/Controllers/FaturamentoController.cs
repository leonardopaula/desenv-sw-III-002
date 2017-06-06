using Infraestrutura.Cadastros;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FaturamentoController : Controller
    {
        private FaturamentoCadastro fc = new FaturamentoCadastro();

        // GET: Faturamento
        public ActionResult Index()
        {
            ViewBag.Pedidos = fc.ObterPedidosPagamentoPendente();

            return View();
        }

        public ActionResult ListagemPendentesEnvio()
        {
            ViewBag.Pedidos = fc.ObterPedidosPendentesEnvio();
            return View();
        }
    }
}