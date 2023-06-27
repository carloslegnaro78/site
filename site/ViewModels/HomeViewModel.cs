using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produtos> ProdutosMaisVendidos { get; set; }
    }
}
