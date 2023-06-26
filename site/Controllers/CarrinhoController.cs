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
    }
}