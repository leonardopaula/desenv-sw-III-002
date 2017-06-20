using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infraestrutura.Mapeamento
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("Funcionario");
            HasKey(f => f.Id);
            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nome).HasMaxLength(250).IsRequired();
            Property(u => u.Login).HasMaxLength(50).IsRequired();
            Property(u => u.Senha).HasMaxLength(200).IsRequired();
            Property(u => u.Email).HasMaxLength(150).IsRequired();
            Property(f => f.Matricula).IsRequired();
        }
    }
}
