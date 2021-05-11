using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
	enum Direction
	{ 
		Stop,
		Up,
		Right,
		Down,
		Left
	}

	class PotentialMethod
	{
		private static Tarrif endAndStartLoopTarrif;

		public static void OptimisePlan(Tarrifs tarrifs, U[] u, V[] v)
		{
			int row = -1;
			int column = -1;

			int max = -1;

			for (int i = 0; i < tarrifs.NumberOfRows; ++i)
			{
				for (int j = 0; j < tarrifs.NumberOfColumns; ++j)
				{
					if (tarrifs[i, j].HasProduct)
						continue;

					int tarrifScore = u[i].Number + v[j].Number - tarrifs[i, j].Cost;

					if (tarrifScore > 0 &&
						((row == -1 && column == -1) || tarrifScore > max))
					{
						row = i;
						column = j;
						max = tarrifScore;
					}
				}
			}

			
			if (row != -1 && column != -1)
			{
				endAndStartLoopTarrif = tarrifs[row, column];
				var loop = FindNextValueOfLoop(tarrifs, row, column, null, new List<Tarrif>() { endAndStartLoopTarrif });
			
				int min = loop[1].QuantityOfProduct;
				for (int i = 3; i < loop.Count; i += 2)
				{
					if (loop[i].QuantityOfProduct < min)
						min = loop[i].QuantityOfProduct;
				}

				for (int i = 0; i < loop.Count; i += 2)
				{
					loop[i].QuantityOfProduct += min;
					loop[i + 1].QuantityOfProduct -= min;
				}

				Console.WriteLine(tarrifs.ToString());
			}
		}

		private static List<Tarrif> FindNextValueOfLoop(Tarrifs tarrifs, int row, int column, Tarrif previous, List<Tarrif> loop)
		{
			int originalRow = row;
			int originalColumn = column;

			var up = GetUpNext(tarrifs, ref row, column);
			if (up != null && !up.Equals(previous))
			{
				var upLoop = Next(tarrifs, row, column, up, tarrifs[originalRow, originalColumn], loop);
				if (upLoop != null)
					return upLoop;
			}

			row = originalRow;
			column = originalColumn;

			var right = GetRightNext(tarrifs, row, ref column);
			if (right != null && !right.Equals(previous))
			{
				var rightLoop = Next(tarrifs, row, column, right, tarrifs[originalRow, originalColumn], loop);
				if (rightLoop != null)
					return rightLoop;
			}

			row = originalRow;
			column = originalColumn;

			var down = GetDownNext(tarrifs, ref row, column);
			if (down != null && !down.Equals(previous))
			{
				var downLoop = Next(tarrifs, row, column, down, tarrifs[originalRow, originalColumn], loop);
				if (downLoop != null)
					return downLoop;
			}

			row = originalRow;
			column = originalColumn;

			var left = GetLeftNext(tarrifs, row, ref column);
			if (left != null && !left.Equals(previous))
			{
				var leftLoop = Next(tarrifs, row, column, left, tarrifs[originalRow, originalColumn], loop);
				if (leftLoop != null)
					return leftLoop;
			}

			return null;
		}

		private static List<Tarrif> Next(Tarrifs tarrifs, int row, int column, Tarrif ts, Tarrif previous, List<Tarrif> loop)
		{
			if (ts.Equals(endAndStartLoopTarrif))
				return loop;

			var newLoop = new List<Tarrif>();
			newLoop.AddRange(loop);
			newLoop.Add(ts);

			return FindNextValueOfLoop(tarrifs, row, column, previous, newLoop);
		}

		private static Tarrif GetUpNext(Tarrifs tarrifs, ref int row, int column)
		{
			for (int i = row - 1; i > -1; --i)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[i, column]))
					return tarrifs[i, column];
			}

			for (int i = row - 1; i > -1; --i)
			{
				if (tarrifs[i, column].HasProduct)
				{
					row = i;
					return tarrifs[i, column];
				}
			}
			return null;
		}

		private static Tarrif GetRightNext(Tarrifs tarrifs, int row, ref int column)
		{
			for (int j = column + 1; j < tarrifs.NumberOfColumns; ++j)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[row, j]))
					return tarrifs[row, j];
			}

			for (int j = column + 1; j < tarrifs.NumberOfColumns; ++j)
			{
				if (tarrifs[row, j].HasProduct)
				{
					column = j;
					return tarrifs[row, j];
				}
			}
			return null;
		}

		private static Tarrif GetDownNext(Tarrifs tarrifs, ref int row, int column)
		{
			for (int i = row + 1; i < tarrifs.NumberOfRows; ++i)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[i, column]))
					return tarrifs[i, column];
			}

			for (int i = row + 1; i < tarrifs.NumberOfRows; ++i)
			{
				if (tarrifs[i, column].HasProduct)
				{
					row = i;
					return tarrifs[i, column];
				}
			}
			return null;
		}


		private static Tarrif GetLeftNext(Tarrifs tarrifs, int row, ref int column)
		{
			for (int j = column - 1; j > -1; --j)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[row, j]))
					return tarrifs[row, j];
			}

			for (int j = column - 1; j > -1; --j)
			{
				if (tarrifs[row, j].HasProduct)
				{
					column = j;
					return tarrifs[row, j];
				}
			}
			return null;
		}
	}
}
