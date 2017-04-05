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

        private long idFuncionario { get; set; }
        private long matricula { get; set; }
    }
}
