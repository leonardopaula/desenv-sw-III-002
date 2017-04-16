using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Cadastros
{
    public class FornecedorCadastro
    {
        private EFContext contexto;
        public FornecedorCadastro()
        {
            contexto = new EFContext();
        }

        public List<Fornecedor> BuscarTodos()
        {
            IQueryable<Fornecedor> fornecedores = from fornecedor in contexto.Fornecedor
                                           select fornecedor;
            return fornecedores.ToList();
        }
    }
}
