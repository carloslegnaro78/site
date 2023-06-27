
using Microsoft.AspNetCore.Http;
using site.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace site.Models
{
    public class Carrinho
    {
        private readonly ApplicationDbContext _appDbContext;
        private Carrinho(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CarrrinhoId { get; set; }

        public List<CarrinhoItem> CarrinhoItens { get; set; }
        



        //MÉTODOS DA CLASSE
        public static Carrinho GetCarrinho(IServiceProvider services)
        {

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string carId = session.GetString("CarId") ?? Guid.NewGuid().ToString();

            session.SetString("CarId", carId);
            return new Carrinho(context) { CarrrinhoId = carId };
        }

        public void AddToCarrinho(Produtos produto, int quant)
        {
            var carrinhoItem =
                _appDbContext.CarrinhoItens.SingleOrDefault(
                    s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrrinhoId);

           if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    CarrinhoId = CarrrinhoId,
                    Produto = produto,
                    Quatidade = 1
                };

                _appDbContext.CarrinhoItens.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quatidade++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveCarrinho(Produtos produto)
        {
            var carrinhoItem =
                _appDbContext.CarrinhoItens.SingleOrDefault(
                    s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrrinhoId);

            var localQuant = 0;

            if (carrinhoItem != null)
            {
                if (carrinhoItem.Quatidade > 1)
                {
                    carrinhoItem.Quatidade--;
                    localQuant = carrinhoItem.Quatidade;
                }
                else
                {
                    _appDbContext.CarrinhoItens.Remove(carrinhoItem);
                }
            }
            _appDbContext.SaveChanges();

            return localQuant;

        }

        public List<CarrinhoItem> GetCarrinhoItens()
        {
            return CarrinhoItens ??
                (CarrinhoItens =
                    _appDbContext.CarrinhoItens.Where(c => c.CarrinhoId == CarrrinhoId)
                        .Include(s => s.Produto)
                        .ToList());                
        }

        public void LimparCarrinho()
        {
            var carItens = _appDbContext
                .CarrinhoItens
                .Where(car => car.CarrinhoId == CarrrinhoId);

            _appDbContext.CarrinhoItens.RemoveRange(carItens);

            _appDbContext.SaveChanges();
        }

        public decimal GetCarrinhoTotal()
        {
            var total = _appDbContext.CarrinhoItens.Where(c => c.CarrinhoId == CarrrinhoId)
                .Select(c => c.Produto.Preco * c.Quatidade).Sum();
            return total;
        }

    }
}
