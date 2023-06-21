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
                        ImagemUrl = "https://cdn-images.farfetch-contents.com/18/25/78/33/18257833_40996697_600.jpg",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "https://cdn-images.farfetch-contents.com/18/25/78/33/18257833_40996697_600.jpg"

                    },

                    new Produtos
                    {
                        Nome = "Saia",
                        Preco = 200,
                        DescricaoCurta = "Saia Feminina",
                        DescricaoLonga = "Saia diversos tamanhos e diversas cores",
                        Categoria = Categorias["Feminino"],
                        ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmki4s5jGwsf3YB0SCLGEqILJuML_40hXJ4NZlyJk5gXumzXwu0iuKjPhl0i5vwqI0cUY&usqp=CAU",
                        EmEstoque = true,
                        Ativo = true,
                        ImagemMiniaturaUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmki4s5jGwsf3YB0SCLGEqILJuML_40hXJ4NZlyJk5gXumzXwu0iuKjPhl0i5vwqI0cUY&usqp=CAU"

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
