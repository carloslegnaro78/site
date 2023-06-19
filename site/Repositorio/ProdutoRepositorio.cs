using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public IEnumerable<Produtos> Produtos => throw new NotImplementedException();

        public IEnumerable<Produtos> ProdutosMaisVendidos => throw new NotImplementedException();

        public Produtos GetProdutosById(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
