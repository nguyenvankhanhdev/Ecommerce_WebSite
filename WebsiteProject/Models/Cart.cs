using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteProject.Models
{
	public class Cart
	{
		public List<CartItem> Items { get; set; }
		public Cart()
		{
			Items = new List<CartItem>();
		}
	}
	public class CartItem
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string Image { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice => Price * Quantity;
	}
}