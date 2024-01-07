using Microsoft.AspNetCore.Mvc;
using ProductBundles.Services;

namespace ProductBundles.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            ViewBag.Bundles = _homeService.GetAllBundles();
            ViewBag.Products = _homeService.GetAllProducts();
            ViewBag.PossibleBuilds = _homeService.GetPossibleBuilds();

            return View();
        }
    }
}
