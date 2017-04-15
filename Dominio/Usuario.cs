using System;

namespace Dominio
{
    public class Usuario
    {
        public Usuario() { }

        public long Id { get; set; }
        public String Nome { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
    }
}
