using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dinamico
{
    public class DadosPedido
    {
        public string FormaEntrega { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int MeioPagamento { get; set; }
        public string NumeroCartao { get; set; }
        public int MesValidade { get; set; }
        public int AnoValidade { get; set; }
        public string CodSeguranca { get; set; }
        public string ValorFrete { get; set; }
    }
}
