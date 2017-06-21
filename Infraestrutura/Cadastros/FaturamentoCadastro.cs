using Dominio;
using Infraestrutura.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class FaturamentoCadastro
    {
        private EFContext contexto;
        private EmailService servicoEmail;
        public FaturamentoCadastro()
        {
            contexto = new EFContext();
            servicoEmail = new EmailService();
        }

        public List<PedidoCliente> ObterPedidosPagamentoPendente()
        {
            IQueryable<PedidoCliente> pc = contexto.PedidoCliente
                .Include("Cliente")
                .Include("Produtos")
                .Include("Produtos.Produto")
                .Include("EnderecoEntrega")
                .Include("EnderecoEntrega.Cidade")
                .Where(pec => pec.Status == Dominio.Enums.StatusPedido.AguardandoConfirmacaoPagamento);

            return pc.ToList();
        }

        public List<PedidoCliente> ObterPedidosComStatusPagamento()
        {
            var servicoCartao = new CartaoDeCreditoService();

            var pedidos = ObterPedidosPagamentoPendente();
            foreach (var pedidoAtual in pedidos)
            {
                var retorno = servicoCartao.ObterSituacaoPagamento(pedidoAtual.IdPedidoCliente);
                if (retorno.Situacao == CartaoDeCreditoServiceRef.SituacaoPagamento.Aprovado)
                {
                    AlterarStatusParaPendenteDeEnvio(pedidoAtual);
                }
                else
                {
                    if (retorno.Situacao == CartaoDeCreditoServiceRef.SituacaoPagamento.NaoAprovado ||
                        DateTime.Today.Subtract(pedidoAtual.Data).Days > 3)
                    {
                        AlterarStatusParaCancelado(pedidoAtual);
                    }
                }
            }
            return pedidos;
        }

        public void EnviarEmailComNotaFiscal(string notaFiscal, PedidoCliente pedido)
        {
            servicoEmail.SendEmail(
                new List<string>() { pedido.Cliente.Email },
                "Pagamento",
                "Olá " + pedido.Cliente.Nome +
                ", \n O pagamento do seu pedido de número " + pedido.Numero + " foi confirmado. Segue nota fiscal do mesmo:" + notaFiscal);
        }

        public void EnviarEmailPedidoCancelado(PedidoCliente pedido)
        {
            servicoEmail.SendEmail(
                new List<string>() { pedido.Cliente.Email },
                "Pagamento",
                "Olá " + pedido.Cliente.Nome +
                ", \n O pagamento do seu pedido de número " + pedido.Numero + " não foi confirmado, por isso seu pedido foi cancelado.");
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

        public void AlterarStatusParaPendenteDeEnvio(PedidoCliente pedido)
        {
            pedido.Status = Dominio.Enums.StatusPedido.PendenteEnvio;
            contexto.Entry(pedido).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void AlterarStatusParaCancelado(PedidoCliente pedido)
        {
            pedido.Status = Dominio.Enums.StatusPedido.Cancelado;
            contexto.Entry(pedido).State = EntityState.Modified;
            contexto.SaveChanges();
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
            var servicoCorreios = new Correios.CalcPrecoPrazoWSSoapClient("CalcPrecoPrazoWSSoap12");
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
