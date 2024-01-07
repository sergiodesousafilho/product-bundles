using ProductBundles.Domain;
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

        public List<Product> GetAllProducts()
        {
            var products = _dbContext.Product.OrderBy(p => p.Name).ToList();
            return products;
        }

        public Dictionary<int, int> GetPossibleBuilds()
        {
            var retVal = new Dictionary<int, int>();

            var bundles = _dbContext.Bundle.OrderBy(b => b.Name).ToList();

            foreach ( var bundle in bundles) 
            {
                int amountAvailable = CalculateMaxAvailableBundles(bundle);
                retVal.Add(bundle.Id, amountAvailable);
            }

            return retVal;
        }

        private int CalculateMaxAvailableBundles(Bundle bundle)
        {
            int maxAvailable = int.MaxValue;

            foreach (var bundleProduct in bundle.BundleProducts)
            {
                int productAmount = bundleProduct.Product.Amount;
                int requiredAmount = bundleProduct.Amount;

                int availableAmount = productAmount / requiredAmount;
                maxAvailable = Math.Min(maxAvailable, availableAmount);
            }

            foreach (var bundleRelation in bundle.ChildBundles)
            {
                int childBundleId = bundleRelation.ChildBundleId;
                int requiredAmount = bundleRelation.Amount;

                int availableAmount = CalculateMaxAvailableBundles(bundleRelation.ChildBundle) / requiredAmount;
                maxAvailable = Math.Min(maxAvailable, availableAmount);
            }

            return maxAvailable;
        }
    }
}
