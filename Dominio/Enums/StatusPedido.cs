using System.ComponentModel;

namespace Dominio.Enums
{
    public enum StatusPedido
    {
        [Description("Aguardando confirmação de pagamento")]
        AguardandoConfirmacaoPagamento = 1,
        [Description("Pendente de envio")]
        PendenteEnvio = 2,
        [Description("Cancelado")]
        Cancelado = 3,
        [Description("Aguardando coleta")]
        AguardandoColeta = 4,
        [Description("Enviado")]
        Enviado = 5
    }
}
