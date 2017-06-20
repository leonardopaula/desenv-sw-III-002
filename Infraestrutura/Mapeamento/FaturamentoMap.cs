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
            
            HasOptional(p => p.NotaFiscal).WithRequired(n => n.Faturamento).Map(m => { m.MapKey("FaturamentoId"); });
        }
    }
}
