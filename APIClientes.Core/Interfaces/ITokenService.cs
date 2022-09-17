using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientes.Core.Interfaces
{
    public interface ITokenService
    {

        public string GenerateTokenProdutos(string nome, string permissao);

    }
}
