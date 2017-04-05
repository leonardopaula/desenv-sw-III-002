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

        private long idUsuario { get; set; }
        private String nome { get; set; }
        private String usuario { get; set; }
        private String senha { get; set; }
        private String email { get; set; }
    }
}
