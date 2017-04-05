using System.Collections.Generic;

namespace Dominio
{
    public class Produto
    {
        public Produto() { }

        private long IdProduto { get; set; }
        private string Nome { get; set; }
        private float Peso { get; set; }
        private int QuantidadeEmEstoque { get; set; }
        private int QuantidadeEstoqueMinimo { get; set; }
        private string Referencia { get; set; }

        private List<Fornecedor> Fornecedores { get; set; }
    }
}
