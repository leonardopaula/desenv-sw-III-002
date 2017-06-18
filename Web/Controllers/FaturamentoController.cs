using Dominio;
using Infraestrutura.Cadastros;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Web.Controllers
{
    public class FaturamentoController : Controller
    {
        private FaturamentoCadastro fc = new FaturamentoCadastro();

        // GET: Faturamento
        public ActionResult Index()
        {
            var pedidos = fc.ObterPedidosComStatusPagamento();
            foreach (var pedido in pedidos)
            {
                if (pedido.Status == Dominio.Enums.StatusPedido.Cancelado)
                    fc.EnviarEmailPedidoCancelado(pedido);
                else if (pedido.Status == Dominio.Enums.StatusPedido.PendenteEnvio)
                {
                    string notaFiscal = RenderViewToString("_NotaFiscal", pedido);
                    fc.EnviarEmailComNotaFiscal(notaFiscal, pedido);
                }
            }
            ViewBag.Pedidos = pedidos;
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
            }
            catch (Exception e)
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

        public ActionResult EmitirDocumentos(string idPedido)
        {
            var pedido = fc.ObterPedidosPorId(idPedido);

            string htmlText = RenderViewToString("_DocumentoDeTransporte", pedido);

            byte[] buffer = RenderPDF(htmlText);

            return File(buffer, "application/PDF");
        }

        private byte[] RenderPDF(string htmlText)
        {
            byte[] renderedBuffer;

            const int HorizontalMargin = 40;
            const int VerticalMargin = 40;

            using (var outputMemoryStream = new MemoryStream())
            {
                using (var pdfDocument = new Document(PageSize.A4, HorizontalMargin, HorizontalMargin, VerticalMargin, VerticalMargin))
                {
                    iTextSharp.text.pdf.PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, outputMemoryStream);
                    pdfWriter.CloseStream = false;

                    pdfDocument.Open();
                    using (var htmlViewReader = new StringReader(htmlText))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, pdfDocument, htmlViewReader);
                    }

                }

                renderedBuffer = new byte[outputMemoryStream.Position];
                outputMemoryStream.Position = 0;
                outputMemoryStream.Read(renderedBuffer, 0, renderedBuffer.Length);
            }

            return renderedBuffer;
        }

        private string RenderViewToString(string viewNameDocumento, PedidoCliente pedido)
        {
            var renderedView = new StringBuilder();

            var controller = this;


            using (var responseWriter = new StringWriter(renderedView))
            {
                var fakeResponse = new HttpResponse(responseWriter);

                var fakeContext = new HttpContext(System.Web.HttpContext.Current.Request, fakeResponse);

                var fakeControllerContext = new ControllerContext(new HttpContextWrapper(fakeContext), controller.ControllerContext.RouteData,
                    controller.ControllerContext.Controller);

                var oldContext = System.Web.HttpContext.Current;
                System.Web.HttpContext.Current = fakeContext;

                using (var viewPage = new ViewPage())
                {
                    var viewContext = new ViewContext(fakeControllerContext, new FakeView(), new ViewDataDictionary(), new TempDataDictionary(), responseWriter);

                    var html = new HtmlHelper(viewContext, viewPage);
                    html.RenderPartial(viewNameDocumento, pedido);
                    System.Web.HttpContext.Current = oldContext;
                }
            }

            return renderedView.ToString();
        }
    }
    public class FakeView : IView
    {
        #region IView Members

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}