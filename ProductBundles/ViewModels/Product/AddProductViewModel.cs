using System.ComponentModel.DataAnnotations;

namespace ProductBundles.ViewModels.Product
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
