using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");
            HasKey(c => c.IdCidade);
            this.Property(c => c.Nome).IsRequired();

            HasRequired(c => c.Estado).WithMany().HasForeignKey(c => c.IdEstado);
        }
    }
}
