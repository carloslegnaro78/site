using site.Interfaces;
using site.Models;
using System.Collections.Generic;
using System.Linq;

namespace site.Config
{
    public class ConfigProduto : IProdutoRepositorio
    {

        private readonly ICategoriaRepositorio _categogriaRepositorio = new ConfigCategoria();

        public IEnumerable<Produtos> Produtos
        {
            get
            {
                return new List<Produtos>
                {
                    new Produtos {
                        Nome = "Camisa",
                        Preco = 250,
                        DescricaoCurta = "Camisa Polo",
                        DescricaoLonga = "Camisa Polo Masculina diversas cores",
                        Categoria = _categogriaRepositorio.Categorias.First(),
                        ImagemUrl ="https://cdn-images.farfetch-contents.com/18/25/78/33/18257833_40996697_600.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl ="https://cdn-images.farfetch-contents.com/18/25/78/33/18257833_40996697_600.jpg"

                    },

                    new Produtos {
                        Nome = "Saia",
                        Preco = 200,
                        DescricaoCurta = "Saia Feminina",
                        DescricaoLonga = "Saia diversos tamanhos e diversas cores",
                        Categoria = _categogriaRepositorio.Categorias.Last(),
                        ImagemUrl ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmki4s5jGwsf3YB0SCLGEqILJuML_40hXJ4NZlyJk5gXumzXwu0iuKjPhl0i5vwqI0cUY&usqp=CAU",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmki4s5jGwsf3YB0SCLGEqILJuML_40hXJ4NZlyJk5gXumzXwu0iuKjPhl0i5vwqI0cUY&usqp=CAU"

                    },


                };
            }
        }

        public IEnumerable<Produtos> ProdutosMaisVendidos { get; }

        public Produtos GetProdutosById(int produtoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
