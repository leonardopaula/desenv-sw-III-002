using System.ComponentModel;

namespace Dominio.Enums
{
    public enum MeioPagamento
    {
        [Description("Boleto Bancário")]
        Boleto = 1,
        [Description("Cartão de Crédito")]
        CartaoCredito = 2,
        [Description("Cartão de Débito")]
        CartaoDebito = 3
    }
}
