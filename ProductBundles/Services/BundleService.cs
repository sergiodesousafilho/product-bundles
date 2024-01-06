using ProductBundles.Domain;
using ProductBundles.Infrastructure;
using ProductBundles.ViewModels.Home;

namespace ProductBundles.Services
{
    public class BundleService
    {
        private readonly ProductBundlesDbContext _dbContext;

        public BundleService(ProductBundlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            var products = _dbContext.Product.OrderBy(p => p.Name).ToList();                        
            return products;
        }
    }
}
