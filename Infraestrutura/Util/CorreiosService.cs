
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Util
{
    public class CorreiosService
    {
        private Correios.CalcPrecoPrazoWSSoapClient client;

        #region Atributos
        private string nCdEmpresa;
        private string sDsSenha;
        private string nCdServico;
        private string sCepOrigem;
        private string sCepDestino;
        private string nVlPeso;
        private int nCdFormato;
        private decimal nVlComprimento;
        private decimal nVlAltura;
        private decimal nVlLargura;
        private decimal nVlDiametro;
        private string sCdMaoPropria;
        private decimal nVlValorDeclarado;
        private string sCdAvisoRecebimento;
        #endregion

        public CorreiosService(string cdServico, string cepDestino, string peso)
        {
            client = new Correios.CalcPrecoPrazoWSSoapClient();

            nCdEmpresa = "";
            sDsSenha = "";
            nCdServico = cdServico;
            sCepOrigem = "93022750";
            sCepDestino = cepDestino;
            nVlPeso = peso;
            nCdFormato = 1;
            nVlComprimento = nVlAltura = nVlLargura = nVlDiametro = 50.0m;
            sCdMaoPropria = "N";
            nVlValorDeclarado = 0.0m;
            sCdAvisoRecebimento = "N";
        }

        public Correios.cResultado CalculaPrecoPrazo()
        {
            try
            {
                return client
                    .CalcPrecoPrazo(
                    nCdEmpresa, sDsSenha, nCdServico, sCepOrigem,
                    sCepDestino, nVlPeso, nCdFormato, nVlComprimento,
                    nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria,
                    nVlValorDeclarado, sCdAvisoRecebimento
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
