using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	enum Optimality
	{ 
		Optimal,
		Unoptimal,
		HaveProduct
	}

	class Tarrif
	{
		private int cost;
		private int quantityOfProduct;
		private Optimality optimality;

		public Tarrif(int cost)
		{
			this.cost = cost;
			quantityOfProduct = 0;
			optimality = Optimality.Unoptimal;
		}

		public Tarrif(Tarrif other)
		{
			this.cost = other.cost;
			this.quantityOfProduct = other.quantityOfProduct;
		}
	}
}
