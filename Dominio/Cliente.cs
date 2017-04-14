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

        public long idCliente { get; set; }
        public long cpf { get; set; }
        public long rg { get; set; }
    }
}
