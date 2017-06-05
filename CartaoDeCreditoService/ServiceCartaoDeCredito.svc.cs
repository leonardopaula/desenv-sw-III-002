using System;

namespace CartaoDeCreditoService
{
    public class Service1 : IServiceCartaoDeCredito
    {
        
        public RetornoRequisicaoSituacao ObterSituacaoPagamento(RequisicaoSituacao requisicao)
        {
            if (requisicao == null)
            {
                throw new ArgumentNullException("Requisição");
            }

            if (requisicao.IdentificadorPagamento < 10)
            {
                return new RetornoRequisicaoSituacao() { Situacao = SituacaoPagamento.EmAnalise };
            }else 
            if (requisicao.IdentificadorPagamento < 20)
            {
                return new RetornoRequisicaoSituacao() { Situacao = SituacaoPagamento.NaoAprovado };
            }
            return new RetornoRequisicaoSituacao() { Situacao = SituacaoPagamento.Aprovado };
        }
    }
}
