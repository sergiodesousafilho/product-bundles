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
            var bundles = _homeService.GetAllBundles();

            ViewBag.Bundles = bundles;

            return View();
        }
    }
}
