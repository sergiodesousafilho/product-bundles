namespace ProductBundles.ViewModels.Bundle
{
    public class AddBundleViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ChildProduct[] ChildProducts { get; set; }
    }

    public class ChildProduct
    {
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
