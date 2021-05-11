using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class Warehouses
	{
		private int[] stock;

		public int this[int index]
		{
			get => stock[index];
			set => stock[index] = value;
		}

		public int Count { get => stock.Length; }

		public int TotalStock
		{
			get
			{
				int total = 0;
				for (int i = 0; i < Count; ++i)
					total += stock[i];
				return total;
			}
		}

		public Warehouses(int size)
		{
			stock = new int[size];
		}

		public Warehouses(Warehouses other)
		{
			for (int i = 0; i < other.Count; ++i)
				this.stock[i] = other.stock[i];
		}

		public void AddBasis(int stock)
		{
			List<int> newStock = new List<int>(Count + 1);
			for (int i = 0; i < Count; ++i)
				newStock.Add(this.stock[i]);
			newStock.Add(stock);

			this.stock = new int[newStock.Count];
			for (int i = 0; i < newStock.Count; ++i)
				this.stock[i] = newStock[i];
		}

		public override string ToString()
		{
			var warehousesString = new StringBuilder("{ ");
			for (int i = 0; i < Count; ++i)
				warehousesString.Append(i != Count - 1 ? stock[i] + ", " : stock[i] + " }");
			return "Warehouses " + warehousesString.ToString();
		}
	}
}
