using Microsoft.EntityFrameworkCore;
using site.Data;
using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly ApplicationDbContext _appDbContext;

        public ProdutoRepositorio(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Produtos> Produtos => _appDbContext.Produtos.Include( c => c.Categoria );

        public IEnumerable<Produtos> ProdutosMaisVendidos => _appDbContext.Produtos.Where(p => p.Ativo).Include(c => c.Categoria);

        public Produtos GetProdutosById(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
