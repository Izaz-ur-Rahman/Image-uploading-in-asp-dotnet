using ImageUploadingInAspdotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadingInAspdotnet.Controllers
{
    public class ProductController : Controller
    {
        private readonly Product obj;
        ImageDbContext context;
        IWebHostEnvironment env;  // it manage the entire procedure to storing the imgs in project folder...
        public ProductController(ImageDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel obj)
        {
            string fileName = "";
            if (obj.photo != null)
            {
               string folder =  Path.Combine(env.WebRootPath,"images");
                fileName = Guid.NewGuid().ToString() + "_" + obj.photo.FileName; // to make the img name unique...
                string filePath = Path.Combine(folder, fileName);
                obj.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                Product p = new Product()
                {
                    Name = obj.Name,
                    Price = obj.Price,
                    ImagePath = "images/" + fileName
                };
                context.Products.Add(p);
                context.SaveChanges();
                TempData["msg"] = "Product Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
