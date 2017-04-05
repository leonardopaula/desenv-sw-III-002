using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente:Usuario
    {
        public Cliente() { }

        private long idCliente { get; set; }
        private long cpf { get; set; }
        private long rg { get; set; }
    }
}
