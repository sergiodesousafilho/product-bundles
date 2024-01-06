using ProductBundles.Infrastructure;
using ProductBundles.ViewModels.Home;

namespace ProductBundles.Services
{
    public class HomeService
    {
        private readonly ProductBundlesDbContext _dbContext;

        public HomeService(ProductBundlesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BundleViewModel> GetAllBundles()
        {            
            var bundles = _dbContext.Bundle.OrderBy(b => b.Name).ToList();

            var bundlesModel = BundleViewModel.FromEntityList(bundles);

            return bundlesModel;
        }
    }
}
