using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Config;
using site.Interfaces;
using site.ViewModels;

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
            ProdutoListViewModel vm = new ProdutoListViewModel();
            vm.Produtos = _produtoRepositorio.Produtos;
            vm.CategoriaAtual = "ProdutoCategoria";
            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}