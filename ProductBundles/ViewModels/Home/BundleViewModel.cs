﻿using ProductBundles.Domain;
using System.Collections.Generic;

namespace ProductBundles.ViewModels.Home
{
    public class BundleViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public List<BundleProductViewModel> BundleProducts { get; set; } = new List<BundleProductViewModel>();


        public static List<BundleViewModel> FromEntityList(List<Bundle> bundles)
        {
            List<BundleViewModel> retVal = new List<BundleViewModel>();

            foreach (Bundle bundle in bundles)
            { 
                BundleViewModel bundleViewModel = new BundleViewModel() 
                {
                    Id = bundle.Id,
                    Name = bundle.Name,
                    BundleProducts = new List<BundleProductViewModel>()
                };

                foreach(BundleProduct bundleProduct in bundle.BundleProducts)
                {
                    BundleProductViewModel bundleProductViewModel = new BundleProductViewModel()
                    {
                        Id = bundleProduct.Id,
                        BundleId = bundleProduct.BundleId,
                        ParentBundleId = bundleProduct.ParentBundleId,
                        BundleProductId = bundleProduct.BundleProductId,                        
                        ProductId = bundleProduct.ProductId,
                        Amount = bundleProduct.Amount,
                        ProductName = bundleProduct.ProductId.HasValue ? bundleProduct.Product.Name : null,
                        Children = new List<BundleProductViewModel>()
                    };

                    SetChildrenRecursively(bundleProductViewModel, bundleProduct);
                    bundleViewModel.BundleProducts.Add(bundleProductViewModel);
                }

                retVal.Add(bundleViewModel);
            }

            return retVal;
        }

        private static void SetChildrenRecursively(BundleProductViewModel bundleProductViewModel, BundleProduct bundleProduct)
        {
            foreach(BundleProduct childBundleProduct in bundleProduct.ChildBundleProducts)
            {
                BundleProductViewModel childBundleProductViewModel = new BundleProductViewModel()
                {
                    Id = childBundleProduct.Id,
                    BundleId = childBundleProduct.BundleId,
                    ParentBundleId = childBundleProduct.ParentBundleId,
                    BundleProductId = childBundleProduct.BundleProductId,
                    ProductId = childBundleProduct.ProductId,
                    Amount = childBundleProduct.Amount,
                    ProductName = childBundleProduct.ProductId.HasValue ? childBundleProduct.Product.Name : null,
                    Children = new List<BundleProductViewModel>()
                };

                SetChildrenRecursively(bundleProductViewModel, bundleProduct);
                bundleProductViewModel.Children.Add(childBundleProductViewModel);
            }
        }
    }

    public class BundleProductViewModel
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int? BundleProductId { get; set; }
        public int? ProductId { get; set; }
        public int? ParentBundleId { get; set; }
        public int Amount { get; set; } = 0;
        public string? ProductName { get; set; } = string.Empty;
        public List<BundleProductViewModel> Children { get; set; } = new List<BundleProductViewModel>();
    }
}
