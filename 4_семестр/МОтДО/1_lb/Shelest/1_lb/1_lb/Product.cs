using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_lb
{
	public class Product
	{
		private int _id;
		private string _name;
		private double _profitForUnit;
		private int _amountOfMaterials;
		private List<Material> _materialStocks;
		private List<double> _kofMaterialsInProduct;
		private double _maxProfit;
		private List<Product> _leftoverProducts;

		public int ID
		{
			get => _id;
		}

		public string Name
		{
			get => _name;
			set => _name = value;
		}

		public double ProfitForUnit
		{
			get => _profitForUnit;
			set => _profitForUnit = value;
		}

		public int AmountOfMaterials
		{
			get => _amountOfMaterials;
		}

		public List<Material> Stocks
		{
			get => _materialStocks;
		}

		public List<double> Koeficients
		{
			get => _kofMaterialsInProduct;
		}

		public double MaxProfit
		{
			get => _maxProfit;
		}

		public List<Product> LeftoverProduct
		{
			get => _leftoverProducts;
		}

		// Lengths of arrays must be equaled!
		public Product(int index, string name, double profitForUnit, List<Material> materialStocks, List<double> kofMaterialInProduct)
		{
			_id = index;
			_name = name;
			_maxProfit = 0.0;

			if (materialStocks.Count != kofMaterialInProduct.Count)
			{
				_profitForUnit = 0;
				_amountOfMaterials = 0;
			}
			else
			{
				_profitForUnit = profitForUnit;
				_amountOfMaterials = materialStocks.Count;
			}

			_materialStocks = new List<Material>();
			_kofMaterialsInProduct = new List<double>();
			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				_materialStocks.Add(materialStocks[i]);
				_kofMaterialsInProduct.Add(kofMaterialInProduct[i]);
			}

			_leftoverProducts = new List<Product>();
		}

		private bool IsEnoughMaterials(Product product)
		{
			if (_amountOfMaterials != product.Stocks.Count)
			{
				return false;
			}

			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				if (product.Koeficients[i] != 0.0 && _materialStocks[i].Stock == 0.0)
				{
					return false;
				}
			}

			return true;
		}

		private bool IsExistedMaterials()
		{
			return _materialStocks.Any(m => m.Stock != 0.0);
		}

		private static double GetMaxProductProfitWithoutChanges(Product product)
		{
			if (product.AmountOfMaterials == 0)
			{
				return 0.0;
			}

			List<double> maxProductVolume = new List<double>();
			for (int i = 0; i < product.AmountOfMaterials; ++i)
			{
				if (product.Koeficients[i] == 0.0) { continue; }

				maxProductVolume.Add(product.Stocks[i].Stock / product.Koeficients[i]);
			}

			return maxProductVolume.Min() * product.ProfitForUnit;
		}

		public double GetAndFillMaxProductProfit(List<Product> products)
		{
			_maxProfit = GetMaxProductProfitWithoutChanges(this);
			// realProductVolume creaters in GetMaxProductProfitWithoutChanges()
			// But don`t returns
			// So here it`s calculated again, but by another formule
			double realProductVolume = _maxProfit / _profitForUnit;

			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				_materialStocks[i].Stock -= realProductVolume * _kofMaterialsInProduct[i];
			}

			while (IsExistedMaterials())
			{
				int idMaterialWithMaxProfit = -1;
				double maxProfit = 0.0;

				for (int i = 0; i < products.Count; ++i)
				{
					if (i == this.ID) { continue; }

					if (IsEnoughMaterials(products[i]))
					{
						Product iProductWithRealRemainders = new Product(
							i, 
							"",
							products[i]._profitForUnit, 
							this._materialStocks, 
							products[i]._kofMaterialsInProduct
						);

						double profit = GetMaxProductProfitWithoutChanges(iProductWithRealRemainders);
						if (profit > maxProfit)
						{
							maxProfit = profit;
							idMaterialWithMaxProfit = i;
						}
					}
				}

				if (idMaterialWithMaxProfit != -1)
				{
					_maxProfit += maxProfit;
					double productVolume = maxProfit / products[idMaterialWithMaxProfit].ProfitForUnit;

					for (int i = 0; i < _amountOfMaterials; ++i)
					{
						_materialStocks[i].Stock -= productVolume * products[idMaterialWithMaxProfit].Koeficients[i];
					}
					_leftoverProducts.Add(products[idMaterialWithMaxProfit]);
				}
				else
				{
					break;
				}
			}

			return _maxProfit;
		}

		public static Product GetProductWithMaxProfitAmongProducts(List<Product> products)
		{
			if (products.Any(p => p.MaxProfit == 0.0))
			{
				products.ForEach(p => p.GetAndFillMaxProductProfit(products));
			}
			return products
				.Where(p => p.MaxProfit == products.Select(x => x.MaxProfit).Max())
				.First();
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder("Product " + _name + ":\n");

			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				result.Append(_materialStocks[i].ToString())
					.Append(", ")
					.Append(_kofMaterialsInProduct[i])
					.Append("\n");
			}
			return result.ToString();
		}
	}
}
