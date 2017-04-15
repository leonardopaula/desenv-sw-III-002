namespace Dominio
{
    public class Cliente : Usuario
    {
        public Cliente() { }

        public long Cpf { get; set; }
        public long Rg { get; set; }
    }
}
