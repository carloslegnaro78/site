using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Interfaces;
using site.Models;
using site.ViewModels;

namespace site.Controllers
{
    public class HomeController : Controller
    {


        private readonly IProdutoRepositorio _produtoRep;
        public HomeController(IProdutoRepositorio produtoRep)
        {
            _produtoRep = produtoRep;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                ProdutosMaisVendidos = _produtoRep.ProdutosMaisVendidos
            };
            return View(homeVM);
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
