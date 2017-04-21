using System.Runtime.Serialization;
using System.ServiceModel;

namespace FornecedorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceFornecedor
    {

        [OperationContract]
        bool ObterDisponibilidadeProduto(ProdutoConsultado produto);

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
}
