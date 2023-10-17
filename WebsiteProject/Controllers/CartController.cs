using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebsiteProject.Models;

public class CartController : Controller
{
	PhoneDbContext db = new PhoneDbContext();
	private Cart cart = new Cart();
	public ActionResult Index()
	{
		Cart cart = Session["Cart"] as Cart;
		if (cart == null)
		{
			cart = new Cart();
			Session["Cart"] = cart;
		}
		return View(cart);
	}
	public ActionResult AddToCart(int productId)
	{
		Product product = db.Products.Find(productId);

		if (product != null)
		{
			Cart cart = Session["Cart"] as Cart;
			if (cart == null)
			{
				cart = new Cart();
			}

			CartItem existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);

			if (existingItem != null)
			{
				existingItem.Quantity++;
			}
			else
			{
				cart.Items.Add(new CartItem
				{
					ProductId = productId,
					ProductName = product.ProductName,
					Image = product.Image,
					Price = (decimal)product.Price,
					Quantity = 1
				});
			}

			Session["Cart"] = cart;
		}

		return RedirectToAction("Index");
	}
	public ActionResult RemoveCartItem(int productId)
	{
		Cart cart = Session["Cart"] as Cart;

		if (cart != null)
		{
			CartItem itemToRemove = cart.Items.FirstOrDefault(item => item.ProductId == productId);

			if (itemToRemove != null)
			{
				cart.Items.Remove(itemToRemove);
			}
			Session["Cart"] = cart;
		}
		return RedirectToAction("Index");
	}

}
