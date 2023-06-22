using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Carrinho
    {
        public int CarrrinhoId { get; set; }
        public List<CarrinhoItem> CarrinhoItens { get; set; }
    }
}
