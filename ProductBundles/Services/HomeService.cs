using ProductBundles.Domain;
using ProductBundles.Infrastructure;

namespace ProductBundles.Services
{
    public class HomeService
    {
        private readonly ProductBundlesDbContext _dbContext;

        public HomeService(ProductBundlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Bundle> GetAllBundles()
        {            
            var bundles = _dbContext.Bundle.ToList();
            return bundles;
        }
    }
}
