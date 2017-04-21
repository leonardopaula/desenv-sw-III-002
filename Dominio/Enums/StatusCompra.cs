using System.ComponentModel;

namespace Dominio.Enums
{
    public enum StatusCompra
    {
        [Description("Aguardando recebimento")]
        AguardandoRecebimento = 1,
        [Description("Recebido")]
        Recebido = 2
    }
}
