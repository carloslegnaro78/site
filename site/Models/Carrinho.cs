using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using site.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace site.Models
{
    public class Carrinho
    {
        private readonly ApplicationDbContext _appDbContext;

        public Carrinho(IEnumerable<ApplicationDbContext> context)
        {

        }

        private Carrinho(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int CarrrinhoId { get; set; }

        public List<CarrinhoItem> CarrinhoItens { get; set; }
        public string CarrinhoId { get; private set; }

        //MÉTODOS DA CLASSE

        public static Carrinho GetCarrinho(IServiceProvider services)
        {

            ISession sesssion = services.GetRequiredService<HttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetServices<ApplicationDbContext>();
            string carId = sesssion.GetString("CarId") ?? Guid.NewGuid().ToString();

            sesssion.SetString("CarId", carId);

            return new Carrinho(context) { CarrinhoId = carId };
        }

        public void AddToCarrinho(Produtos produto, int quant)
        {
            var carrinhoItem =
                _appDbContext.CarrinhoItens.SingleOrDefault(
                    s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrinhoId);

           if (carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem
                {
                    CarrinhoId = CarrinhoId,
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
                    s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoId == CarrinhoId);

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
                    _appDbContext.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId)
                        .Include(s => s.Produto)
                        .ToList());                
        }
    }
}
