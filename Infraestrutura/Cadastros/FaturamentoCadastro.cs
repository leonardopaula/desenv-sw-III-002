using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class FaturamentoCadastro
    {
        private EFContext contexto;
        public FaturamentoCadastro()
        {
            contexto = new EFContext();
        }

        public List<PedidoCliente> ObterPedidosPagamentoPendente()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento);

            return pc.ToList();
        }

        public List<PedidoCliente> ObterPedidosPendentesEnvio()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.PendenteEnvio);

            return pc.ToList();
        }
    }
}
