using System.Collections.Generic;

namespace Dominio
{
    public class Fornecedor
    {
        public Fornecedor() { }

        private long IdFornecedor { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }

        private List<Produto> Produtos { get; set; }
    }
}
