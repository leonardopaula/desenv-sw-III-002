using System.Runtime.Serialization;
using System.ServiceModel;

namespace CartaoDeCreditoService
{
    [ServiceContract]
    public interface IServiceCartaoDeCredito
    {
        [OperationContract]
        RetornoRequisicaoSituacao ObterSituacaoPagamento(RequisicaoSituacao requisicao);
    }

    [DataContract]
    public class RequisicaoSituacao
    {
        long identificadorPagamento = 0;

        [DataMember]
        public long IdentificadorPagamento
        {
            get { return identificadorPagamento; }
            set { identificadorPagamento = value; }
        }
    }

    [DataContract]
    public class RetornoRequisicaoSituacao
    {
        SituacaoPagamento situacao;

        [DataMember]
        public SituacaoPagamento Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
    }

    public enum SituacaoPagamento
    {
        EmAnalise = 1,
        Aprovado = 2,
        NaoAprovado = 3
    }
}
