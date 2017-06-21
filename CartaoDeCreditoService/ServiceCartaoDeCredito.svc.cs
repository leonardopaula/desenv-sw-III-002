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

             
            if (requisicao.IdentificadorPagamento % 2 == 0)
            {
                return new RetornoRequisicaoSituacao() { Situacao = SituacaoPagamento.Aprovado };
            }
            return new RetornoRequisicaoSituacao() { Situacao = SituacaoPagamento.NaoAprovado };
        }
    }
}
