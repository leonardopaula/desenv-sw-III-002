using Dominio;
using Infraestrutura.Util;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class ClienteCadastro
    {
        private EFContext contexto;
        public ClienteCadastro()
        {
            contexto = new EFContext();
        }

        public Cliente Adicionar(Cliente novoCliente)
        {
            contexto.Cliente.Add(novoCliente);
            contexto.SaveChanges();
            return novoCliente;
        }

        public void Editar(Cliente cliente)
        {
            contexto.Entry(cliente).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Cliente ExisteUsuario(string login, string senha)
        {
            return contexto.Cliente.FirstOrDefault(x => x.Login == login && x.Senha == senha);
        }

        public void Salvar(Cliente novoCliente)
        {
            IQueryable<Cliente> clientes = from cliente in contexto.Cliente
                                          where cliente.Cpf == novoCliente.Cpf || cliente.Rg == novoCliente.Rg
                                       select cliente;
            Cliente clienteExistente = clientes.FirstOrDefault();
            if (clienteExistente != null)
            {
                novoCliente.Id = clienteExistente.Id;
                Editar(novoCliente);
            }else
            {
                Adicionar(novoCliente);
                EmailService email = new EmailService();

                email.SendEmail(new List<string>() { novoCliente.Email }, "4WEB - Usuário cadastrado",
                    $"<h1><b>Bem-Vindo, {novoCliente.Nome}.</b></h1> Seu usuário foi cadastrado com sucesso");
            }
        }
    }
}
