using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");
            HasKey(e => e.IdEndereco);
            this.Property(e => e.Rua).IsRequired();
            this.Property(e => e.Numero);
            this.Property(e => e.CEP);
            this.Property(e => e.Bairro).IsRequired();
            this.Property(e => e.Complemento);

            HasRequired(e => e.Cidade).WithMany().HasForeignKey(e => e.IdCidade);
            
        }
    }
}
