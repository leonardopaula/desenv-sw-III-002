using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class FaturamentoCadastro
    {
        private EFContext contexto;
        public FaturamentoCadastro()
        {
            contexto = new EFContext();
        }

        public List<PedidoCliente> ObterPedidosPagamentoPendente()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Include("Produtos.Produto")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento);

            return pc.ToList();
        }

        public List<PedidoCliente> ObterPedidosPendentesEnvio()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.PendenteEnvio);

            return pc.ToList();
        }

        public List<PedidoCliente> ObterPedidosAguardandoColeta()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.AguardandoColeta);

            return pc.ToList();
        }

        public PedidoCliente ObterPedidosPorId(string idPedido)
        {
            long id = Convert.ToInt64(idPedido);
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Include("Produtos.Produto")
                .Include("EnderecoEntrega")
                .Include("EnderecoEntrega.Cidade")
                .Include("EnderecoEntrega.Cidade.Estado")
                .Where(pec => pec.IdPedidoCliente == id);

            return pc.FirstOrDefault();
        }

        private void AlterarStatusParaAguardandoColeta(PedidoCliente pedido)
        {
            pedido.Status = Dominio.Enums.StatusPedido.AguardandoColeta;
            contexto.Entry(pedido).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void EnviarPedidos(string[] idPedidos)
        {
            string cepUnisinos = "93022750";
            var servicoEmail = new Util.EmailService();
            var servicoCorreios = new Correios.CalcPrecoPrazoWSSoapClient("CalcPrecoPrazoWSSoap");
            foreach (var id in idPedidos)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    long idPesquisa = Convert.ToInt64(id);
                    var pedido = contexto.PedidoCliente
                        .Include("Cliente")
                        .Include("EnderecoEntrega")
                        .FirstOrDefault(p => p.IdPedidoCliente == idPesquisa);
                    servicoCorreios.Open();
                    var retorno = servicoCorreios.CalcPrazoData(
                        "41106", // PAC Varejo
                        cepUnisinos,
                        pedido.EnderecoEntrega.CEP.ToString(),
                        DateTime.Now.ToString("dd/MM/yyyy"));

                    if (retorno.Servicos.Count() > 0)
                    {
                        if (!string.IsNullOrEmpty(retorno.Servicos.FirstOrDefault().Erro) ||
                            !string.IsNullOrEmpty(retorno.Servicos.FirstOrDefault().MsgErro))
                        {
                            throw new Exception(retorno.Servicos.FirstOrDefault().Erro + " - " + retorno.Servicos.FirstOrDefault().MsgErro);
                        }
                        else
                        {
                            AlterarStatusParaAguardandoColeta(pedido);
                            servicoEmail.SendEmail(
                                new List<string>() { pedido.Cliente.Email },
                                "Envio",
                                "Olá " + pedido.Cliente.Nome +
                                ", \n Seu pedido será enviado em breve." +
                                "O prazo de entrega de seu pedido pelos correios é " + retorno.Servicos.FirstOrDefault().PrazoEntrega + " dias.");
                        }

                    }
                }
            }

        }
    }
}
