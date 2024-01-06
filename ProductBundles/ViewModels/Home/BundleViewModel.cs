
using System.Collections.Generic;
using ProductBundles.Domain;

namespace ProductBundles.ViewModels.Home
{
    public class BundleViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Amount { get; set; } = 0;
        public List<BundleProductViewModel> BundleProducts { get; set; } = new List<BundleProductViewModel>();        
        public List<BundleViewModel> ChildBundles { get; set; } = new List<BundleViewModel>();


        public static List<BundleViewModel> FromEntityList(List<Domain.Bundle> bundles)
        {
            List<BundleViewModel> retVal = new List<BundleViewModel>();

            foreach (Domain.Bundle bundle in bundles)
            { 
                BundleViewModel bundleViewModel = new BundleViewModel() 
                {
                    Id = bundle.Id,
                    Name = bundle.Name,
                    BundleProducts = new List<BundleProductViewModel>()
                };

                foreach (BundleProduct bundleProduct in bundle.BundleProducts)
                {
                    BundleProductViewModel bundleProductViewModel = new BundleProductViewModel()
                    {
                        Id = bundleProduct.Id,
                        BundleId = bundleProduct.BundleId,
                        ProductId = bundleProduct.ProductId,
                        Amount = bundleProduct.Amount,
                        ProductName = bundleProduct.Product.Name                        
                    };                                        
                    bundleViewModel.BundleProducts.Add(bundleProductViewModel);
                }

                foreach (BundleRelation childBundleRelation in bundle.ChildBundles)
                {
                    BundleViewModel childBundleViewModel = new BundleViewModel()
                    {
                        Id = childBundleRelation.ChildBundleId,
                        Name = childBundleRelation.ChildBundle.Name,
                        Description = childBundleRelation.ChildBundle.Description,
                        Amount = childBundleRelation.Amount
                    };
                    SetChildrenRecursively(childBundleRelation.ChildBundle, childBundleViewModel);
                    bundleViewModel.ChildBundles.Add(childBundleViewModel);
                }

                retVal.Add(bundleViewModel);
            }

            return retVal;
        }

        private static void SetChildrenRecursively(Domain.Bundle bundle, BundleViewModel bundleViewModel)
        {
            foreach (BundleProduct bundleProduct in bundle.BundleProducts)
            {
                BundleProductViewModel bundleProductViewModel = new BundleProductViewModel()
                {
                    Id = bundleProduct.Id,
                    BundleId = bundleProduct.BundleId,
                    ProductId = bundleProduct.ProductId,
                    Amount = bundleProduct.Amount,
                    ProductName = bundleProduct.Product.Name
                };
                bundleViewModel.BundleProducts.Add(bundleProductViewModel);
            }

            foreach (BundleRelation childBundleRelation in bundle.ChildBundles)
            {                
                BundleViewModel childBundleViewModel = new BundleViewModel()
                {
                    Id = childBundleRelation.ChildBundleId,
                    Amount = childBundleRelation.Amount,
                    Description = childBundleRelation.ChildBundle.Description,
                    Name = childBundleRelation.ChildBundle.Name                    
                };
                  
                SetChildrenRecursively(childBundleRelation.ChildBundle, childBundleViewModel);
                bundleViewModel.ChildBundles.Add(childBundleViewModel);
            }
        }
    }

    public class BundleProductViewModel
    {
        public int Id { get; set; }
        public int BundleId { get; set; }        
        public int ProductId { get; set; }        
        public int Amount { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;                
    }
    
}
