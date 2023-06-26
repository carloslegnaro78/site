using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Interfaces;
using site.Models;

namespace site.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRep;
        private readonly Carrinho _carrinho;

        public CarrinhoController()
        {
                
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}