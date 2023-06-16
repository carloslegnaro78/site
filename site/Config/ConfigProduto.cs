using site.Interfaces;
using site.Models;
using System.Collections.Generic;
using System.Linq;

namespace site.Config
{
    public class ConfigProduto : IProdutoRepositorio
    {

        private readonly ICateogriaRepositorio _categogriaRepositorio = new ConfigCategoria();

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
                        Categoria = _categogriaRepositorio.Cateogrias.First(),
                        ImagemUrl ="",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl =""

                    },

                    
                };
            }
        }
    }
}
