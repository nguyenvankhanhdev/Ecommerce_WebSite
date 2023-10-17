using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		PhoneDbContext db = new PhoneDbContext();
		public ActionResult Index(string search = "", int PageNo = 1)
		{
			ViewBag.Search = search;
			List<Product> products = db.Products.Where(t => t.ProductName.Contains(search)).ToList();
			int NoOfRecordsPerPage = 12;
			int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
			int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
			ViewBag.PageNo = PageNo;
			ViewBag.NoOfPage = NoOfPages;
			products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
			ViewBag.Brands = db.Brands.ToList();
			return View(products);
		}
		public ActionResult Details(long id)
		{
			ViewBag.Brands = db.Brands.ToList();
			Product p = db.Products.Where(t => t.ProductId == id).FirstOrDefault();
			return View(p);
		}
		//public ActionResult GetMoreProducts(int page)
		//{
		//	int PageSize = 5;
		//	var products = db.Products
		//					.OrderBy(p => p.ProductId) 
		//					.Skip((page - 1) * PageSize)
		//					.Take(PageSize)
		//					.ToList();
		//	return View("_ProductListPartial", products);
		//}		
		public ActionResult ProductByBrand(string brandName )
		{
			ProductModel model = new ProductModel();
			model.Brands = db.Brands.ToList();
			model.Products = db.Products.Where(t => t.Brand.BrandName == brandName).ToList();
			return View(model);
		}

	}
}