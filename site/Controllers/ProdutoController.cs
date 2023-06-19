using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Config;

namespace site.Controllers
{
    public class ProdutoController : Controller
    {
        public ProdutoController(ConfigProduto produtoConfig, ConfigCategoria categoriaConfig)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}