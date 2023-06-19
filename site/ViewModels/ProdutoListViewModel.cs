using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.ViewModels
{
    public class ProdutoListViewModel
    {
        public IEnumerable<Produtos>Produtos { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
