using site.Data;
using site.Interfaces;
using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site.Repositorio
{
    public class VendaRepositorio:IVendaRepositorio
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly Carrinho _carrinho;


        public VendaRepositorio(ApplicationDbContext appDbContext, Carrinho carrinho)
        {
            _appDbContext = appDbContext;
            _carrinho = carrinho;
        }


        public void CriarVenda (Venda venda)
        {
            venda.DataVenda = DateTime.Now;

            _appDbContext.Vendas.Add(venda);

            var carrinhoItens = _carrinho.CarrinhoItens;

            foreach (var carrinhoItem in carrinhoItens)
            {
                var vendaDet = new DetalhesVenda()
                {
                    Quantidade = carrinhoItem.Quatidade,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    VendaId = venda.VendaId,
                    Preco = carrinhoItem.Produto.Preco
                };

                _appDbContext.DetalhesVendas.Add(vendaDet);
            }

            _appDbContext.SaveChanges();
        }
    }
}
