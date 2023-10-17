using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebsiteProject.Models;

namespace WebsiteProject.APIControllerss
{
    public class ProductsController : ApiController
    {

        public List<Product> get()
        {
            PhoneDbContext db = new PhoneDbContext();
            var productsData = db.Products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Price,
                p.Image,
                p.Chip,
                p.Display,
                p.Ram,
                p.Brand,
                p.Category,
            }).ToList();
            List<Product> products = productsData.Select(p => new Product()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                Image = p.Image,
                Chip = p.Chip,
                Ram = p.Ram,
                Display = p.Display,
                Brand = p.Brand,
                Category = p.Category,
            }).ToList();

            return products;
        }
        public class ProductDTO
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public string Image { get; set; }
            public string Chip { get; set; }
            public string Display { get; set; }
            public string Ram { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
        }
        public List<ProductDTO> GetProducts(int id)
        {
            PhoneDbContext db = new PhoneDbContext();
            return (from p in db.Products
                    where p.ProductId == id
                    select new ProductDTO
                    {
                        ProductId = (int)p.ProductId,
                        ProductName = p.ProductName,
                        Price = (double)p.Price,
                        Image = p.Image,
                        Chip = p.Chip,
                        Ram = p.Ram,
                        Display = p.Display,
                        Brand = p.Brand.BrandName,
                        Category=p.Category.CategoryName,
                    }).ToList();
        }


    }
}
