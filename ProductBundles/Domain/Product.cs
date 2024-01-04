namespace ProductBundles.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public List<BundleProduct> BundleProducts { get; set; }
    }
}
