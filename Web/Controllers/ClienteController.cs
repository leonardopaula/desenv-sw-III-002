using Dominio;
using Infraestrutura.Cadastros;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteCadastro cc = new ClienteCadastro();

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(string nome, string email, string login, string senha, string rg, string cpf)
        {
            bool retorno = true;
            string mensagem = string.Empty;

            Cliente novoCliente = new Cliente() {
                Cpf = Convert.ToInt64(cpf),
                Email = email,
                Login = login,
                Nome = nome, Rg = Convert.ToInt64(rg),
                Senha = senha
            };
            try
            {
                cc.Salvar(novoCliente);
            }catch(Exception e)
            {
                retorno = false;
                mensagem = e.Message;
            }

            var json = JsonConvert.SerializeObject(new { Mensagem = mensagem, Situacao = retorno }, 
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Content(json, "application/json");
        }
    }
}