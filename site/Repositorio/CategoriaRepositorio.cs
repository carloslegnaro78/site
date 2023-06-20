using site.Data;
using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Repositorio
{   

    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _appDbContext;

        public CategoriaRepositorio(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Categoria> Categorias => _appDbContext.Categorias;
    }
}
