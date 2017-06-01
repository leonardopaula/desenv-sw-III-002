using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");
            HasKey(e => e.IdEstado);
            this.Property(e => e.Nome).IsRequired();
            this.Property(e => e.UF).IsRequired();
        }
    }
}
