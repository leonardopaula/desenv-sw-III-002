using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            Map(m => { m.MapInheritedProperties(); m.ToTable("Cliente"); });
            Property(c => c.Cpf).IsRequired();
            Property(c => c.Rg).IsRequired();
        }
    }
}
