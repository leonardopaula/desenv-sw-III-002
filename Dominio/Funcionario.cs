using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Funcionario: Usuario
    {
        public Funcionario () { }

        public long idFuncionario { get; set; }
        public long matricula { get; set; }
    }
}
