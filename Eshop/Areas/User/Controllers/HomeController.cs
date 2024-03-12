using Eshop.Data.Repository;
//using Eshop.Data.Migrations;
using Eshop.Model.Models;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;


namespace Eshop.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitofWork unitofWork;

        public HomeController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            List<Category> categories=unitofWork.Category.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Products()
        {
            return View();

        }
        public IActionResult Register()
        {
            return View();
        }
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Cart()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Single(int? Id)
		{
			var product = unitofWork.Product.Get(u => u.Id == Id, includeProperties: "productImages,colors");
		
			return View(product);
		}
        public IActionResult CategoryProducts(int? Id)
        {
            var category=unitofWork.Category.Get(u=>u.Id==Id,includeProperties: "products,products.productImages");
            return View(category);
        }
    }
}
