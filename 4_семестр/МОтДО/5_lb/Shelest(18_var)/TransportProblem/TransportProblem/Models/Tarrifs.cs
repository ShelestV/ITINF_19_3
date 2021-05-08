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
		}
	}
}
