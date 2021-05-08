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

		public Warehouses(int size)
		{
			stock = new int[size];
		}
	}
}
