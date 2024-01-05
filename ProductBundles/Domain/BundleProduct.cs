namespace ProductBundles.Domain
{
    public class BundleProduct
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int? BundleProductId { get; set; }
        public int? ProductId { get; set; }
        public int? ParentBundleId { get; set; }
        public int Amount { get; set; }

        public virtual Bundle Bundle { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<BundleProduct> ChildBundleProducts { get; set; }
    }
}
