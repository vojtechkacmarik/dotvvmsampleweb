using System.Collections.Generic;
using System.Linq;
using DotVVM.SampleWeb.BL.DTO;
using DotVVM.SampleWeb.DAL;

namespace DotVVM.SampleWeb.Web.Services
{
    public class ProductService
    {
        private readonly AppDbContext dbContext;

        public ProductService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProductListDTO> GetProducts()
        {
            return dbContext.Products
                .Select(p => new ProductListDTO()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice
                })
                .ToList();
        }
    }
}