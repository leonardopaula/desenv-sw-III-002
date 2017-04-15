using System.ComponentModel;

namespace Dominio.Enums
{
    public enum StatusPedidoFornecedor
    {
        [Description("Aguardando recebimento")]
        AguardandoRecebimento = 1,
        [Description("Recebido")]
        Recebido = 2
    }
}
