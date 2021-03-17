using System;
using System.Collections.Generic;

namespace _1_lb
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Product> products = new List<Product>();
			// 0 700
			products.Add(new Product(0, 1000, 
				new List<Material>() 
				{ 
					new Material(0, 700),
					new Material(1, 300),
					new Material(2, 150)
				}, 
				new List<double>() { 0.7, 0.3, 0.0 }));
			products.Add(new Product(1, 1100,
				new List<Material>()
				{
					new Material(0, 700),
					new Material(1, 300),
					new Material(2, 150)
				},
				new List<double>() { 0.7, 0.3, 0.2 }));
			products.Add(new Product(2, 1200,
				new List<Material>()
				{
					new Material(0, 700),
					new Material(1, 300),
					new Material(2, 150)
				},
				new List<double>() { 0.7, 0.2, 0.3 }));

			double maxProfit = 0.0;
			foreach (var product in products)
			{
				Console.WriteLine(product.ToString());
				Console.WriteLine();
				double profit = product.GetMaxProductProfit(products);
				Console.WriteLine(product.ID + " product : " + profit);
				Console.WriteLine();
				Console.WriteLine(product.ToString());
				Console.WriteLine();
				if (profit > maxProfit)
				{
					maxProfit = profit;
				}
			}
			Console.WriteLine("Max profit : " + maxProfit);
		}
	}
}
