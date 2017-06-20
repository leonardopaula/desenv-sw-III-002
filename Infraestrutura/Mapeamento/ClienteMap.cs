using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(c => c.Id);
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nome).HasMaxLength(250).IsRequired();
            Property(u => u.Login).HasMaxLength(50).IsRequired();
            Property(u => u.Senha).HasMaxLength(200).IsRequired();
            Property(u => u.Email).HasMaxLength(150).IsRequired();
            Property(c => c.Cpf).IsRequired();
            Property(c => c.Rg).IsRequired();
        }
    }
}
