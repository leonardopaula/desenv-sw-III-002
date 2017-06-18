namespace Infraestrutura.Util
{
    public class CartaoDeCreditoService
    {
        private CartaoDeCreditoServiceRef.ServiceCartaoDeCreditoClient servico;


        public CartaoDeCreditoService()
        {
            servico = new CartaoDeCreditoServiceRef.ServiceCartaoDeCreditoClient("BasicHttpBinding_IServiceCartaoDeCredito");
        }

        public CartaoDeCreditoServiceRef.RetornoRequisicaoSituacao ObterSituacaoPagamento(long identificador)
        {
            var requisicao = new CartaoDeCreditoServiceRef.RequisicaoSituacao() { IdentificadorPagamento = identificador };
            return servico.ObterSituacaoPagamento(requisicao);
        }
    }
}
