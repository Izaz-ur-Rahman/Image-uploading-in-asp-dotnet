using ImageUploadingInAspdotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadingInAspdotnet.Controllers
{
    public class ProductController : Controller
    {
        private readonly Product obj;
        ImageDbContext context;
        public ProductController(ImageDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
