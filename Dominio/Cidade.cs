namespace Dominio
{
    public class Cidade
    {
        public long IdCidade { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public long IdEstado { get; set; }
    }
}
