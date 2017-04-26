using System.Collections.Generic;

namespace Dominio
{
    public class Produto
    {
        public Produto() { }

        public long IdProduto { get; set; }
        public string Nome { get; set; }
        public float Peso { get; set; }
        public float Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int QuantidadeEstoqueMinimo { get; set; }
        public string Referencia { get; set; }
        public string UrlImagem { get; set; }

        public List<Fornecedor> Fornecedores { get; set; }
    }
}
