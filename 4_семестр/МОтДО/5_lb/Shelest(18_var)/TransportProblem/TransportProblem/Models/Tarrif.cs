using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class Tarrif
	{
		private int cost;
		private int quantityOfProduct;
		private bool optimale;

		public int Cost { get => cost; }
		public int QuantityOfProduct 
		{ 
			get => quantityOfProduct;
			set
			{
				if (value >= 0)
				{
					quantityOfProduct = value;
					optimale = value != 0;
				}
			}
		}
		public bool Optimality { get => optimale; }

		public Tarrif(int cost)
		{
			this.cost = cost;
			quantityOfProduct = 0;
			optimale = false;
		}

		public Tarrif(Tarrif other)
		{
			this.cost = other.cost;
			this.quantityOfProduct = other.quantityOfProduct;
		}

		public override string ToString()
		{
			return cost + (optimale ? "[" + quantityOfProduct + "]" : "");
		}
	}
}
