using CS68.Service;
using Microsoft.AspNetCore.Mvc;

namespace CS68.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index(){
            _logger.LogInformation("Index action");
            return "Toi la Index cua First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("Hi", "Chao ban");
        }

        public IActionResult ViewProduct(int? id){
            var product =  _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}