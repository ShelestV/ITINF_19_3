using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _1_lb.Tests
{
	[TestClass]
	public class ProductTests
	{
		[TestMethod]
		public void GetMaxProductProfitTest()
		{
			List<Product> products = new List<Product>();
			// 0 700
			products.Add(new Product(0, "К1", 1000,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.3, 0.0 }));
			products.Add(new Product(1, "К2", 1100,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.3, 0.2 }));
			products.Add(new Product(2, "К3", 1200,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.2, 0.3 }));

			double expected = 1100000.0;
			double actual = products.Select(p => p.GetAndFillMaxProductProfit(products)).Max();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetProductWithMaxProfit()
		{
			List<Product> products = new List<Product>();
			// 0 700
			products.Add(new Product(0, "К1", 1000,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.3, 0.0 }));
			products.Add(new Product(1, "К2", 1100,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.3, 0.2 }));
			products.Add(new Product(2, "К3", 1200,
				new List<Material>()
				{
					new Material("Сахарный песок", 700),
					new Material("Патока", 300),
					new Material("Фруктовое пюре", 150)
				},
				new List<double>() { 0.7, 0.2, 0.3 }));

			string expected = products[2].Name;
			string actual = Product.GetProductWithMaxProfitAmongProducts(products).Name;

			Assert.AreEqual(expected, actual);
		}
	}
}
