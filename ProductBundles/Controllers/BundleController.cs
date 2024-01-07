using Microsoft.AspNetCore.Mvc;
using ProductBundles.Services;
using ProductBundles.ViewModels.Bundle;

namespace ProductBundles.Controllers
{
    [Route("bundle")]
    public class BundleController : Controller
    {
        private readonly BundleService _bundleService;

        public BundleController(BundleService bundleService)
        {
            _bundleService = bundleService;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {            
            ViewBag.Bundles = _bundleService.GetAllBundles();
            ViewBag.Products = _bundleService.GetAllProducts();
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromForm]AddBundleViewModel bundle)
        {
            if(ModelState.IsValid)
            {                
                bool success = _bundleService.AddBundle(bundle);
                return Json(new { success = success });
            }
            return Json(new { success = false });
        }
    }
}
