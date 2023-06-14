using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Categoria
    {

        public int CategoriaId { get; set; }

        public string NomeCateogira { get; set; }

        public string Descricao { get; set; }

        public List<Produtos> Produtos { get; set; }

    }
}
