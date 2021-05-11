using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class TransportProblem
	{
		private Clients clients;
		private Warehouses warehouses;
		private Tarrifs tarrifs;

		private V[] v;
		private U[] u;

		public TransportProblem(Tarrifs tarrifs, Warehouses warehouses, Clients clients)
		{
			this.clients = new Clients(clients);
			this.warehouses = new Warehouses(warehouses);
			this.tarrifs = new Tarrifs(tarrifs);

			Balance();
		}

		private void Balance()
		{
			int totalDemand = clients.TotalDemand;
			int totalStock = warehouses.TotalStock;

			if (totalDemand > totalStock)
			{
				warehouses.AddBasis(totalDemand - totalStock);
				tarrifs.AddStockBasis();
			}
			else if (totalDemand < totalStock)
			{
				clients.AddBasis(totalStock - totalDemand);
				tarrifs.AddDemandBasis();
			}
		}

		public Tarrifs GetOptimalPlan()
		{
			var plan = NorthWestAngleMethod.GetBasePlan(tarrifs, warehouses, clients);

			RecalculateVandU(tarrifs);
			while (tarrifs.IsOptimal(u, v))
			{
				RecalculateVandU(tarrifs);

			}
			return plan;
		}

		private void RecalculateVandU(Tarrifs tarrifs)
		{
			u = new U[tarrifs.NumberOfRows];
			v = new V[tarrifs.NumberOfColumns];

			FillUndefineds(u);
			FillUndefineds(v);

			u[0].Number = 0;

			while (!IsAllDefined(u) && !IsAllDefined(v))
			{
				NextIteration(tarrifs);
				if (tarrifs.NumberOfOccupied < tarrifs.TeoreticNumberOfOccupied)
					SetImaginary(tarrifs);
			}
		}

		private void FillUndefineds(Undefined[] undefineds)
		{
			for (int i = 0; i < undefineds.Length; ++i)
				undefineds[i] = new Undefined();
		}

		private bool IsAllDefined(Undefined[] undefineds)
		{
			for (int i = 0; i < undefineds.Length; ++i)
				if (undefineds[i].IsUndefined)
					return false;
			return true;
		}

		private void NextIteration(Tarrifs tarrifs)
		{
			for (int i = 0; i < tarrifs.NumberOfRows; ++i)
			{
				for (int j = 0; j < tarrifs.NumberOfColumns; ++j)
				{
					if (!tarrifs[i, j].Optimality)
						continue;

					if (v[j].IsUndefined && !u[i].IsUndefined)
						v[j].Number = tarrifs[i, j].Cost - u[i].Number;

					if (!v[j].IsUndefined && u[i].IsUndefined)
						u[i].Number = tarrifs[i, j].Cost - u[i].Number;
				}
			}
		}

		private void SetImaginary(Tarrifs tarrifs)
		{
			int row = -1;
			int column = -1;
			for (int i = 0; i < tarrifs.NumberOfRows; ++i)
			{
				for (int j = 0; j < tarrifs.NumberOfColumns; ++j)
				{
					if (tarrifs[i, j].Optimality ||
						(v[j].IsUndefined && u[i].IsUndefined))
						continue;

					if ((row == -1 && column == -1) || 
						tarrifs[i, j].Cost < tarrifs[row, column].Cost)
					{
						row = i;
						column = j;
					}
				}
			}

			if (row != -1 && column != -1)
			{
				tarrifs[row, column].QuantityOfProduct = 0;
				tarrifs.NumberOfOccupied += 1;
			}
		}
	}
}
