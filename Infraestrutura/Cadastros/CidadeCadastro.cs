using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Cadastros
{
    public class CidadeCadastro
    {
        private EFContext contexto;

        public CidadeCadastro()
        {
            contexto = new EFContext();
        }

        public List<Cidade> BuscaCidades(string prefixo)
        {
            return (from c in contexto.Cidade where c.Nome.StartsWith(prefixo) select c).OrderBy(x => x.Nome).ToList();
        }

        public Cidade BuscaCidade(string nome)
        {
            return (from c in contexto.Cidade where c.Nome == nome select c).FirstOrDefault();
        }
    }
}
