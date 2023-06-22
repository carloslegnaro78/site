using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class CarrinhoItem
    {
        [Key]
        public int CarrinhoItemId { get; set; }
        public Produtos Produto { get; set; }
        public int Quatidade { get; set; }
        public string CarrinhoId { get; set; }
    }
}
