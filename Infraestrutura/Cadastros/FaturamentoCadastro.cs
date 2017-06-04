using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Infraestrutura.Cadastros
{
    public class FaturamentoCadastro
    {
        private EFContext contexto;
        public FaturamentoCadastro()
        {
            contexto = new EFContext();
        }

        public List<PedidoCliente> pedidosPendentesEnvio()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento);

            return pc.ToList();
        }
    }
}
