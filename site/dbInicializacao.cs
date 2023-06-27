using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using site.Data;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace site
{
    public class dbInicializacao
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context =
                serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(Categorias.Select(c => c.Value));
            }

            if (!context.Produtos.Any())
            {
                context.AddRange
                (
                    new Produtos
                    {
                        Nome = "Camisa",
                        Preco = 250,
                        DescricaoCurta = "Camisa Polo",
                        DescricaoLonga = "Camisa Polo Masculina diversas cores",
                        Categoria = Categorias["Masculino"],
                        ImagemUrl = "https://s3.amazonaws.com/milanicamisaria.com.br/catalog/product/cache/1/image/2000x3000/9df78eab33525d08d6e5fb8d27136e95/c/a/camisa_gola_polo_mostarda_manga_curta_-_camisaria_milani_3_.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "https://s3.amazonaws.com/milanicamisaria.com.br/catalog/product/cache/1/image/2000x3000/9df78eab33525d08d6e5fb8d27136e95/c/a/camisa_gola_polo_mostarda_manga_curta_-_camisaria_milani_3_.jpg"

                    },

                    new Produtos
                    {
                        Nome = "Saia",
                        Preco = 200,
                        DescricaoCurta = "Saia Feminina",
                        DescricaoLonga = "Saia diversos tamanhos e diversas cores",
                        Categoria = Categorias["Feminino"],
                        ImagemUrl = "https://50375.cdn.simplo7.net/static/50375/sku/saias-b16-saia-evase-preta-com-cinto--p-1638134915738.jpg",
                        EmEstoque = true,
                        Ativo = false,
                        ImagemMiniaturaUrl = "https://50375.cdn.simplo7.net/static/50375/sku/saias-b16-saia-evase-preta-com-cinto--p-1638134915738.jpg"

                    }
                );
            }

            context.SaveChanges();

        }

        private static Dictionary<string, Categoria> categorias;

        public static Dictionary<string, Categoria> Categorias
        {
            get
            {
                if (categorias == null)
                {
                    var generoList = new Categoria[]
                    {
                            new Categoria { NomeCateogira = "Masculino", Descricao ="Todos os Produtos Masculinos" },
                            new Categoria { NomeCateogira = "Feminino", Descricao ="Todos os Produtos Feminino" }
                    };

                    categorias = new Dictionary<string, Categoria>();

                    foreach (Categoria genero in generoList)
                    {
                        categorias.Add(genero.NomeCateogira, genero);
                    }
                }

                return categorias;
            }
        }
    }
}
