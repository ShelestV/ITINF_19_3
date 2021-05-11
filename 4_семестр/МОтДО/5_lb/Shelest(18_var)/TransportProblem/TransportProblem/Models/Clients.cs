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

		public int Count { get => demand.Length; }

		public int TotalDemand 
		{
			get
			{
				int total = 0;
				for (int i = 0; i < Count; ++i)
					total += demand[i];
				return total;
			}
		}

		public Clients(int size)
		{
			demand = new int[size];
		}

		public Clients(Clients other)
		{
			for (int i = 0; i < other.Count; ++i)
				this.demand[i] = other.demand[i];
		}

		public void AddBasis(int demand)
		{
			List<int> newDemand = new List<int>(Count + 1);
			for (int i = 0; i < Count; ++i)
				newDemand.Add(this.demand[i]);
			newDemand.Add(demand);

			this.demand = new int[newDemand.Count];
			for (int i = 0; i < newDemand.Count; ++i)
				this.demand[i] = newDemand[i];
		}

		public override string ToString()
		{
			var clientsString = new StringBuilder("{ ");
			for (int i = 0; i < Count; ++i)
				clientsString.Append(i != Count - 1 ? demand[i] + ", " : demand[i] + " }");
			return "Clients " + clientsString.ToString();
		}
	}
}
