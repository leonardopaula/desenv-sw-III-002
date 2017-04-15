using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(u => u.IdUsuario);
            Property(u => u.Nome).HasMaxLength(250).IsRequired();
            Property(u => u.Login).HasMaxLength(50).IsRequired();
            Property(u => u.Senha).HasMaxLength(200).IsRequired();
            Property(u => u.Email).HasMaxLength(150).IsRequired();
        }
    }
}
