using System.Collections.Generic;
using System.Text;

namespace _1_lb
{
	class Product
	{
		private int _id;
		private double _profitForUnit;
		private int _amountOfMaterials;
		private List<Material> _materialStocks;
		private List<double> _kofMaterialsInProduct;

		public int ID
		{
			get => _id;
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

		// Lengths of arrays must be equaled!
		public Product(int index, double profitForUnit, List<Material> materialStocks, List<double> kofMaterialInProduct)
		{
			_id = index;

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
		}

		private static double Min(List<double> collection)
		{
			if (collection.Count == 0)
			{
				return 0.0;
			}

			double min = collection[0];
			for (int i = 1; i < collection.Count; ++i)
			{
				if (collection[i] < min)
				{
					min = collection[i];
				}
			}

			return min;
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
			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				if (_materialStocks[i].Stock != 0.0)
				{
					return true;
				}
			}

			return false;
		}

		public static double GetMaxProductProfitWithoutChanges(Product product)
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

			double realProductVolume = Min(maxProductVolume);
			double profit = realProductVolume * product.ProfitForUnit;

			return profit;
		}

		public double GetMaxProductProfit(List<Product> products)
		{
			double resultProfit = GetMaxProductProfitWithoutChanges(this);
			// realProductVolume creaters in GetMaxProductProfitWithoutChanges()
			// But don`t returns
			// So here it`s calculated again, but by another formule
			double realProductVolume = resultProfit / _profitForUnit;

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
					if (_id == i) { continue; }

					if (IsEnoughMaterials(products[i]))
					{
						Product iProductWithRealRemainders =
						   new Product(i, products[i]._profitForUnit, this._materialStocks, products[i]._kofMaterialsInProduct);

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
					resultProfit += maxProfit;
					double productVolume = maxProfit / products[idMaterialWithMaxProfit].ProfitForUnit;

					for (int i = 0; i < _amountOfMaterials; ++i)
					{
						_materialStocks[i].Stock -= productVolume * products[idMaterialWithMaxProfit].Koeficients[i];
					}
				}
				else
				{
					break;
				}
			}

			return resultProfit;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder("Product " + _id + ":\n");
			for (int i = 0; i < _amountOfMaterials; ++i)
			{
				result.Append("Material " + i + " : stock = " + _materialStocks[i].Stock + ", " + _kofMaterialsInProduct[i] + "\n");
			}
			return result.ToString();
		}
	}
}
