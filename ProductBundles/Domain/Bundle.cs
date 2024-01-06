namespace ProductBundles.Domain
{
    public class Bundle
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public virtual List<BundleProduct> BundleProducts { get; set; } 
        public virtual List<BundleRelation> ChildBundles { get; set; }
    }
}
