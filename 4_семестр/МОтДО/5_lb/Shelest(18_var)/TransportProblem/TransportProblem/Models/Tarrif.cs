using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class Tarrif
	{
		private string id;

		private int cost;
		private int quantityOfProduct;
		private bool hasProduct;

		public int Cost { get => cost; }
		public int QuantityOfProduct 
		{ 
			get => quantityOfProduct;
			set
			{
				if (value >= 0)
				{
					quantityOfProduct = value;
					hasProduct = value != 0;
				}
			}
		}
		public bool HasProduct { get => hasProduct; }

		public Tarrif(int cost, int row, int column)
		{
			id = row.ToString() + " " + column.ToString();
			this.cost = cost;
			quantityOfProduct = 0;
			hasProduct = false;
		}

		public Tarrif(Tarrif other)
		{
			this.id = other.id;
			this.cost = other.cost;
			this.quantityOfProduct = other.quantityOfProduct;
			this.hasProduct = other.hasProduct;
		}

		public void SetImaginary()
		{
			quantityOfProduct = 0;
			hasProduct = true;
		}

		public override string ToString()
		{
			return cost + (hasProduct ? "[" + quantityOfProduct + "]" : "");
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			return obj != null &&
				   obj is Tarrif tarrif &&
				   this.id.Equals(tarrif.id);
		}

		public override int GetHashCode()
		{
			int hashCode = 618115868;
			hashCode = hashCode * -1521134295 + cost.GetHashCode();
			hashCode = hashCode * -1521134295 + quantityOfProduct.GetHashCode();
			hashCode = hashCode * -1521134295 + hasProduct.GetHashCode();
			return hashCode;
		}
	}
}
