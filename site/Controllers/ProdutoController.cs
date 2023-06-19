using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Config;
using site.Interfaces;

namespace site.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRep, ICategoriaRepositorio cateogriaRep)
        {
            _categoriaRepositorio = cateogriaRep;
            _produtoRepositorio = produtoRep;
        }

        public ViewResult List()
        {
            var produtos = _produtoRepositorio.Produtos;

            return View(produtos);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}