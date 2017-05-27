using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/css/site.css")
                    .Include("~/Content/css/Produtos.css")
                );

            bundles.Add(new ScriptBundle("~/Scripts/scripts").Include(
                "~/Scripts/Site.js"));
            bundles.Add(new ScriptBundle("~/Scripts/reporEstoque")
                .Include("~/Scripts/Site.js")
                .Include("~/Scripts/Compra/index.js"));
            bundles.Add(new ScriptBundle("~/Scripts/listagemNaoRecebidas")
                .Include("~/Scripts/Site.js")
                .Include("~/Scripts/Compra/listagemNaoRecebidas.js"));

            bundles.Add(new ScriptBundle("~/Scripts/venda").Include(
                "~/Scripts/Venda/index.js"));

            bundles.Add(new ScriptBundle("~/Scripts/carrinho").Include(
                "~/Scripts/Carrinho/index.js"));
        }
    }
}
