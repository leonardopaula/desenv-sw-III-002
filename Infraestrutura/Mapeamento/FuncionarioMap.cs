using Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            Map(m => { m.MapInheritedProperties(); m.ToTable("Funcionario"); });
            Property(f => f.Matricula).IsRequired();
        }
    }
}
