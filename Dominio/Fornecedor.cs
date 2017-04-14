using System.Collections.Generic;

namespace Dominio
{
    public class Fornecedor
    {
        public Fornecedor() { }

        public long IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
