using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Interfaces;
using site.Models;
using site.ViewModels;

namespace site.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRep;
        private readonly Carrinho _carrinho;

        public CarrinhoController( IProdutoRepositorio produtoRep, Carrinho carrinho)
        {
            _produtoRep = produtoRep;
            _carrinho = carrinho;
        }

        public ViewResult Index()
        {
            var itens = _carrinho.GetCarrinhoItens();
            _carrinho.CarrinhoItens = itens;

            var carVm = new CarrinhoViewModel
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoTotal()
            };

            return View(carVm);
        }

        public RedirectToActionResult AddCarrinho(int produtoId)
        {
            var selProduto = _produtoRep.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (selProduto != null)
            {
                _carrinho.AddToCarrinho(selProduto, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveCarrinho(int produtoId)
        {
            var selProduto = _produtoRep.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (selProduto != null)
            {
                _carrinho.RemoveCarrinho(selProduto);
            }
            return RedirectToAction("Index");
        }

    }
}