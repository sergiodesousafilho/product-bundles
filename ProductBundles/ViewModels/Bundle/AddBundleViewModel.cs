namespace ProductBundles.ViewModels.Bundle
{
    public class AddBundleViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ChildProduct[] ChildProducts { get; set; } = new ChildProduct[0];
        public ChildBundle[] ChildBundles { get; set; } = new ChildBundle[0];
    }

    public class ChildProduct
    {
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }

    public class ChildBundle
    {
        public int BundleId { get; set; }
        public int BundleAmount { get; set; }
    }
}
