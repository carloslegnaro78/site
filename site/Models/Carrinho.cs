using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using site.Data;
using System;
using System.Collections.Generic;

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
    }
}
