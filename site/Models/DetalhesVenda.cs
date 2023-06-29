using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class DetalhesVenda
    {
        [Key]
        public int VendaDetalheId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public virtual Produtos Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
