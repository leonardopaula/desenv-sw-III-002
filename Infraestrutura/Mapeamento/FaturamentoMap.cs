using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FaturamentoMap : EntityTypeConfiguration<Faturamento>
    {
        public FaturamentoMap()
        {
            ToTable("Faturamento");
            HasKey(f => f.IdFaturamento);
            Property(f => f.IdFaturamento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(f => f.PedidoCliente).WithOptional(p => p.Faturamento);
            HasRequired(f => f.Pagamento).WithOptional(p => p.Faturamento);
        }
    }
}
