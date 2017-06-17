using Infraestrutura.Cadastros;
using System;
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

        public ActionResult Enviar(string pedidos)
        {
            string[] idsPedidos = pedidos.Split(',');
            bool retorno = true;
            string mensagem = string.Empty;
            try
            {
                fc.EnviarPedidos(idsPedidos);
            }catch(Exception e)
            {
                retorno = false;
                mensagem = e.Message;
            }
            return Json(new { Situacao = retorno, Mensagem = retorno ? "Pedidos enviados com sucesso" : mensagem }); ;
        }

        public ActionResult ListagemEmissaoDocTransporte()
        {
            ViewBag.Pedidos = fc.ObterPedidosAguardandoColeta();
            return View();
        }

        public ActionResult EmitirDocumentos(string idPedidos)
        {
            return View();
        }
    }
}