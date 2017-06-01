namespace Dominio
{
    public class Endereco
    {
        public long IdEndereco { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public Cidade Cidade { get; set; }
        public long IdCidade { get; set; }

        public long CEP { get; set; }

        public string Complemento { get; set; }
        
    }
}
