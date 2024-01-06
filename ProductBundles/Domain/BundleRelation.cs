using System.ComponentModel.DataAnnotations.Schema;

namespace ProductBundles.Domain
{
    public class BundleRelation
    {
        public int Id { get; set; }        
        public int Amount { get; set; }
        public int ParentBundleId { get; set; }
        public int ChildBundleId { get; set; }
                
        public virtual Bundle ParentBundle { get; set; }        
        public virtual Bundle ChildBundle { get; set; }
    }
}
