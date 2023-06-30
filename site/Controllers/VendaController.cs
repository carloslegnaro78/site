using Microsoft.AspNetCore.Mvc;
using site.Interfaces;
using site.Models;

namespace site.Controllers
{





    [Produces("application/json")]
    [Route("api/Venda")]
    public class VendaController : Controller
    {
        private readonly IVendaRepositorio _vendaRep;
        private readonly Carrinho _carrinho;

        public VendaController(IVendaRepositorio vendaRep, Carrinho carrinho)
        {
            _vendaRep = vendaRep;
            _carrinho = carrinho;
        }







        [HttpPost]

        public IActionResult Checkout(Venda venda)
        {
            var itens = _carrinho.GetCarrinhoItens();
            _carrinho.CarrinhoItens = itens;
            if(_carrinho.CarrinhoItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, adicione um produto");
            }

            if (ModelState.IsValid)
            {
                _vendaRep.CriarVenda(venda);
                _carrinho.LimparCarrinho();
                return RedirectToAction("CheckoutComplete");
            }

            return View(venda);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Obrigado pela compra! :)";
            return View();
        }
    }
}