using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoMap()
        {
            ToTable("Pagamento");
            HasKey(p => p.IdPagamento);
            Property(p => p.Data).IsRequired();
            Property(p => p.MeioPagamento).IsRequired();
            Property(p => p.Origem).IsRequired();

            HasOptional(p => p.Faturamento).WithRequired(f => f.Pagamento).Map(m => { m.MapKey("PagamentoId"); });
        }
    }
}
