using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FornecedorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceFornecedor
    {

        [OperationContract]
        RetornoRequisicao ObterDisponibilidadeProduto(ProdutoConsultado produto);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ProdutoConsultado
    {
        int quantidadeRequerida = 0;
        string referencia = string.Empty;

        [DataMember]
        public int QuantidadeRequerida
        {
            get { return quantidadeRequerida; }
            set { quantidadeRequerida = value; }
        }

        [DataMember]
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
    }

    [DataContract]
    public class RetornoRequisicao
    {
        int quantidadeRequerida = 0;
        string referencia = string.Empty;
        string mensagem = string.Empty;
        DateTime? dataEnvio = (DateTime?)null;

        public RetornoRequisicao(int quantidade, string referencia)
        {
            this.quantidadeRequerida = quantidade;
            this.referencia = referencia;
        }

        [DataMember]
        public int QuantidadeRequerida
        {
            get { return quantidadeRequerida; }
            set { quantidadeRequerida = value; }
        }

        [DataMember]
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        [DataMember]
        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        [DataMember]
        public DateTime? DataEnvio
        {
            get { return dataEnvio; }
            set { dataEnvio = value; }
        }
    }
}
