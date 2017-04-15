namespace Dominio
{
    public class Cliente : Usuario
    {
        public Cliente() { }

        public long IdCliente { get; set; }
        public long Cpf { get; set; }
        public long Rg { get; set; }
    }
}
