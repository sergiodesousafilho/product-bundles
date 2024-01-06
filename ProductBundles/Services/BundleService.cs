using ProductBundles.Domain;
using ProductBundles.Infrastructure;
using ProductBundles.ViewModels.Bundle;
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

        public bool AddBundle(AddBundleViewModel bundleModel)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {                    
                    Bundle bundle = new Bundle() 
                    { 
                        Name = bundleModel.Name, 
                        Description = bundleModel.Description,
                        BundleProducts = new List<BundleProduct>() 
                    };
                    _dbContext.Bundle.Add(bundle);
                    _dbContext.SaveChanges();

                    foreach (ChildProduct childProductModel in bundleModel.ChildProducts)
                    {
                        BundleProduct bundleProduct = new BundleProduct()
                        {
                            ProductId = childProductModel.ProductId,
                            Amount = childProductModel.ProductAmount,
                            BundleId = bundle.Id                            
                        };
                        _dbContext.BundleProduct.Add(bundleProduct);
                    }

                    foreach (ChildBundle childBundleModel in bundleModel.ChildBundles)
                    {
                        BundleRelation bundleRelation = new BundleRelation()
                        {
                            ParentBundleId = bundle.Id,
                            ChildBundleId = childBundleModel.BundleId,
                            Amount = childBundleModel.BundleAmount
                        };
                        _dbContext.BundleRelation.Add(bundleRelation);
                    }

                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                    
                }
                catch (Exception ex)
                {                       
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<BundleViewModel> GetAllBundles()
        {
            var bundles = _dbContext.Bundle.ToList();

            var bundlesModel = BundleViewModel.FromEntityList(bundles);

            return bundlesModel;
        }
    }
}
