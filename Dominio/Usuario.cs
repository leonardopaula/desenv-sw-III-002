using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public Usuario() { }

        public long idUsuario { get; set; }
        public String nome { get; set; }
        public String usuario { get; set; }
        public String senha { get; set; }
        public String email { get; set; }
    }
}
