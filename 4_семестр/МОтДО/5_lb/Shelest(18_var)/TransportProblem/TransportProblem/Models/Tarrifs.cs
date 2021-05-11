using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	class Tarrifs
	{
		private Tarrif[][] tarrifs;
		private int numberOfOccupied;
		private bool isDegeneratePlan;

		public int TeoreticNumberOfOccupied { get => NumberOfColumns + NumberOfRows - 1; }
		public int NumberOfOccupied { get => numberOfOccupied; set => numberOfOccupied = value; }
		public int NumberOfRows { get => tarrifs.Length; }
		public int NumberOfColumns { get => tarrifs[0].Length; }

		public Tarrif this[int row, int column]
		{
			get => tarrifs[row][column];
			set => tarrifs[row][column] = new Tarrif(value);
		}

		public Tarrifs(int numberOfRows, int numberOfColumns)
		{
			if (numberOfRows <= 0 || numberOfColumns <= 0)
				throw new FormatException();

			tarrifs = new Tarrif[numberOfRows][];
			for (int i = 0; i < numberOfRows; ++i)
				tarrifs[i] = new Tarrif[numberOfColumns];

			numberOfOccupied = 0;
			isDegeneratePlan = true;
		}

		public Tarrifs(Tarrifs other)
		{
			tarrifs = new Tarrif[other.NumberOfRows][];
			for (int i = 0; i < other.NumberOfRows; ++i)
				tarrifs[i] = new Tarrif[other.NumberOfColumns];

			for (int i = 0; i < NumberOfRows; ++i)
			{
				for (int j = 0; j < NumberOfColumns; ++j)
				{
					tarrifs[i][j] = new Tarrif(other[i, j]);
				}
			}

			numberOfOccupied = other.numberOfOccupied;
			isDegeneratePlan = other.isDegeneratePlan;
		}

		public void AddDemandBasis()
		{
			var newTarrifs = GetTarrifsCopy();
			var newDemand = new List<Tarrif>();
			for (int j = 0; j < NumberOfColumns; ++j)
				newDemand.Add(new Tarrif(0));
			newTarrifs.Add(newDemand);

			NewTarrifs(newTarrifs);
		}

		public void AddStockBasis()
		{
			var newTarrifs = GetTarrifsCopy();
			for (int i = 0; i < NumberOfRows; ++i)
				newTarrifs[i].Add(new Tarrif(0));

			NewTarrifs(newTarrifs);
		}

		private List<List<Tarrif>> GetTarrifsCopy()
		{
			var copy = new List<List<Tarrif>>();
			for (int i = 0; i < NumberOfRows; ++i)
			{
				var inter = new List<Tarrif>();
				for (int j = 0; j < NumberOfColumns; ++j)
				{
					inter.Add(this.tarrifs[i][j]);
				}
				copy.Add(inter);
			}
			return copy;
		}

		private void NewTarrifs(List<List<Tarrif>> tarrifs)
		{
			this.tarrifs = new Tarrif[tarrifs.Count][];
			for (int i = 0; i < tarrifs[0].Count; ++i)
				this.tarrifs[i] = new Tarrif[tarrifs[i].Count];

			for (int i = 0; i < NumberOfRows; ++i)
			{
				for (int j = 0; j < NumberOfColumns; ++j)
				{
					this.tarrifs[i][j] = tarrifs[i][j];
				}
			}
		}

		public int GetTotalDemand(int column)
		{
			int total = 0;
			for (int i = 0; i < NumberOfRows; ++i)
				total += tarrifs[i][column].QuantityOfProduct;
			return total;
		}

		public int GetTotalStock(int row)
		{
			int total = 0;
			for (int j = 0; j < NumberOfColumns; ++j)
				total += tarrifs[row][j].QuantityOfProduct;
			return total;
		}

		public bool IsOptimal(U[] u, V[] v)
		{
			for (int i = 0; i < NumberOfRows; ++i)
			{
				for (int j = 0; j < NumberOfColumns; ++j)
				{
					if (tarrifs[i][j].Optimality)
						continue;

					if (u[i].Number + v[j].Number > tarrifs[i][j].Cost)
						return false;
				}
			}
			return true;
		}

		public override string ToString()
		{
			var tarrifsString = new StringBuilder("Tarrifs");
			for (int i = 0; i < NumberOfRows; ++i)
			{
				tarrifsString.Append(Environment.NewLine);
				for (int j = 0; j < NumberOfColumns; ++j)
				{
					tarrifsString.Append(tarrifs[i][j]).Append("\t");
				}
			}
			return tarrifsString.ToString() + Environment.NewLine;
		}
	}
}
