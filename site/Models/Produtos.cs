using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site.Models
{
    public class Produtos
    {
        [Key]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string DescricaoCurta { get; set; }

        public string DescricaoLonga { get; set; }

        public decimal Preco { get; set; }

        public string ImagemUrl { get; set; }

        public string ImagemMiniaturaUrl { get; set; }

        public bool Ativo { get; set; }

        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

    }
}
