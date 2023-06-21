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
                        ImagemUrl ="https://s3.amazonaws.com/milanicamisaria.com.br/catalog/product/cache/1/image/2000x3000/9df78eab33525d08d6e5fb8d27136e95/c/a/camisa_gola_polo_mostarda_manga_curta_-_camisaria_milani_3_.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl ="https://s3.amazonaws.com/milanicamisaria.com.br/catalog/product/cache/1/image/2000x3000/9df78eab33525d08d6e5fb8d27136e95/c/a/camisa_gola_polo_mostarda_manga_curta_-_camisaria_milani_3_.jpg"

                    },

                    new Produtos {
                        Nome = "Saia",
                        Preco = 200,
                        DescricaoCurta = "Saia Feminina",
                        DescricaoLonga = "Saia diversos tamanhos e diversas cores",
                        Categoria = _categogriaRepositorio.Categorias.Last(),
                        ImagemUrl ="https://50375.cdn.simplo7.net/static/50375/sku/saias-b16-saia-evase-preta-com-cinto--p-1638134915738.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl ="https://50375.cdn.simplo7.net/static/50375/sku/saias-b16-saia-evase-preta-com-cinto--p-1638134915738.jpg"

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
