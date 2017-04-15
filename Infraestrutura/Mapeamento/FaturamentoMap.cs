using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FaturamentoMap : EntityTypeConfiguration<Faturamento>
    {
        public FaturamentoMap()
        {
            ToTable("Faturamento");
            HasKey(f => f.IdFaturamento);
            HasRequired(f => f.NotaFiscal).WithOptional(n => n.Faturamento);
            HasRequired(f => f.PedidoCliente).WithOptional(p => p.Faturamento);
            HasRequired(f => f.Pagamento).WithOptional(p => p.Faturamento);
        }
    }
}
