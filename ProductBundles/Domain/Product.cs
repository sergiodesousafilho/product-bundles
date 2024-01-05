namespace ProductBundles.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public virtual List<BundleProduct> BundleProducts { get; set; }
    }
}
