using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Interfaces
{
    interface IProdutoRepositorio
    {
        IEnumerable<Produtos> Produtos { get; }
        IEnumerable<Produtos> ProdutosMaisVendidos { get; }

        Produtos GetProdutosById(int produtoId);
    }
}
