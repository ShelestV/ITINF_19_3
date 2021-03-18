using System;
using System.Collections.Generic;

namespace _1_lb
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Product> products = new List<Product>();
			List<Material> materials = new List<Material>();
			
			string agree = "";
			int numberOfMaterial = 0;
			while (agree != "n")
			{
				Console.Clear();
				Console.WriteLine("Would you like to add material?(y/n)");
				agree = Console.ReadLine();
				if (agree == "y")
				{
					string name;
					double stock;
					Console.WriteLine("Enter material name : ");
					name = Console.ReadLine();
					Console.WriteLine("Enter stock : ");
					try
					{
						stock = Convert.ToDouble(Console.ReadLine());
					}
					catch (FormatException)
					{
						continue;
					}
					materials.Add(new Material(name, stock));
					++numberOfMaterial;
				}
			}

			if (numberOfMaterial == 0)
			{
				Console.WriteLine("You should have added materials!\nGoodbye");
				return;
			}

			agree = "";
			int indexProduct = 0;
			while (agree != "n")
			{
				Console.Clear();
				Console.WriteLine("Would you like to add product?(y/n)");
				agree = Console.ReadLine();
				if (agree == "y")
				{
					string name;
					double profitForUnit;
					List<Material> productMaterials = new List<Material>();
					List<double> kofMaterialInProduct = new List<double>();
					Console.WriteLine("Enter name of product : ");
					name = Console.ReadLine();
					try
					{
						Console.WriteLine("Enter profit for unit : ");
						profitForUnit = Convert.ToDouble(Console.ReadLine());
						for (int i = 0; i < numberOfMaterial; ++i)
						{
							productMaterials.Add(new Material(materials[i]));
							Console.WriteLine("How much we need " + materials[i].Name + "?");
							kofMaterialInProduct.Add(Convert.ToDouble(Console.ReadLine()));
						}
					}
					catch (FormatException)
					{
						continue;
					}
					products.Add(new Product(indexProduct, name, profitForUnit, productMaterials, kofMaterialInProduct));
					++indexProduct;
				}
				else if (agree == "n")
				{
					Console.Clear();
					if (indexProduct == 0)
					{
						Console.WriteLine("You should have added products!\nGoodbye");
						return;
					}

					Product result = Product.GetProductWithMaxProfitAmongProducts(products);

					Console.WriteLine("Max profit = " + result.MaxProfit);
					Console.WriteLine();

					Console.WriteLine(result.ToString());

					if (result.LeftoverProduct.Count != 0)
					{
						Console.WriteLine("Products made from leftover : ");
						result.LeftoverProduct.ForEach(product => Console.WriteLine(product.ToString()));
					}
				}
			}
		}
	}
}
