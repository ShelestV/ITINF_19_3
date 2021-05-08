using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class Clients
	{
		private int[] demand;

		public int this[int index]
		{
			get => demand[index];
			set => demand[index] = value;
		}

		public Clients(int size)
		{
			demand = new int[size];
		}
	}
}
