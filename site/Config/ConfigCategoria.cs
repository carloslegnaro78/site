using site.Interfaces;
using site.Models;
using System.Collections.Generic;


namespace site.Config
{
    public class ConfigCategoria : ICategoriaRepositorio
    {
        IEnumerable<Categoria> ICategoriaRepositorio.Categorias
        {
            get
            {
                return new List<Categoria>
                {
                    new Categoria { NomeCateogira = "Masculino", Descricao ="Todos os Produtos Masculinos" },
                    new Categoria { NomeCateogira = "Feminino", Descricao ="Todos os Produtos Feminino" },
                };
            }
        }
    }
}
