using Microsoft.EntityFrameworkCore;
using ProductBundles.Domain;
using ProductBundles.Infrastructure;
using ProductBundles.ViewModels.Product;
using System.Reflection.Metadata;

namespace ProductBundles.Services
{
    public class ProductService
    {
        private readonly ProductBundlesDbContext _dbContext;

        public ProductService(ProductBundlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddProduct(AddProductViewModel productModel)
        {   
            try
            {
                Product product = new Product()
                {
                    Name = productModel.Name,
                    Amount = productModel.Amount
                };

                _dbContext.Product.Add(product);
                _dbContext.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }                            
        }
    }
}
