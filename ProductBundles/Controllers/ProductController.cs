using Microsoft.AspNetCore.Mvc;
using ProductBundles.Services;
using ProductBundles.ViewModels.Product;

namespace ProductBundles.Controllers
{
    [Route("product")]
    public class ProductController: Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {            
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromForm] AddProductViewModel product)
        {
            if (ModelState.IsValid)
            {             
                _productService.AddProduct(product);
                return RedirectToAction("index", "home");
            }
            return View(product);
        }
    }
}
