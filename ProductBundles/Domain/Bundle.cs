namespace ProductBundles.Domain
{
    public class Bundle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BundleProduct> BundleProducts { get; set; }
    }
}
