
using System.Collections.Generic;
using ProductBundles.Domain;

namespace ProductBundles.ViewModels.Home
{
    public class BundleViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public List<BundleProductViewModel> BundleProducts { get; set; } = new List<BundleProductViewModel>();
        public List<ChildBundleViewModel> ChildBundles { get; set; } = new List<ChildBundleViewModel>();


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

                    //SetChildrenRecursively(bundleProductViewModel, bundleProduct);
                    bundleViewModel.BundleProducts.Add(bundleProductViewModel);
                }

                foreach (BundleRelation childBundleRelation in bundle.ChildBundles)
                {
                    ChildBundleViewModel childBundleViewModel = new ChildBundleViewModel()
                    {
                        Id = childBundleRelation.ChildBundleId,
                        Name = childBundleRelation.ChildBundle.Name,
                        Description = childBundleRelation.ChildBundle.Description,
                        Amount = childBundleRelation.Amount
                    };
                    bundleViewModel.ChildBundles.Add(childBundleViewModel);
                }

                retVal.Add(bundleViewModel);
            }

            return retVal;
        }

        //private static void SetChildrenRecursively(BundleProductViewModel bundleProductViewModel, BundleProduct bundleProduct)
        //{
        //    foreach(BundleProduct childBundleProduct in bundleProduct.ChildBundleProducts)
        //    {
        //        BundleProductViewModel childBundleProductViewModel = new BundleProductViewModel()
        //        {
        //            Id = childBundleProduct.Id,
        //            BundleId = childBundleProduct.BundleId,                    
        //            ProductId = childBundleProduct.ProductId,
        //            Amount = childBundleProduct.Amount,
        //            ProductName = childBundleProduct.ProductId.HasValue ? childBundleProduct.Product.Name : null,
        //            Children = new List<BundleProductViewModel>()
        //        };

        //        SetChildrenRecursively(bundleProductViewModel, bundleProduct);
        //        bundleProductViewModel.Children.Add(childBundleProductViewModel);
        //    }
        //}
    }

    public class BundleProductViewModel
    {
        public int Id { get; set; }
        public int BundleId { get; set; }        
        public int ProductId { get; set; }        
        public int Amount { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;                
    }

    public class ChildBundleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Amount { get; set;} = 0;
    }
}
