using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportProblem.Models
{
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

			Console.WriteLine("Potential method");
			if (row != -1 && column != -1)
			{
				endAndStartLoopTarrif = tarrifs[row, column];
				Console.WriteLine(tarrifs.ToString());

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

			}
		}

		private static List<Tarrif> FindNextValueOfLoop(Tarrifs tarrifs, int row, int column, Tarrif previous, List<Tarrif> loop)
		{
			int originalRow = row;
			int originalColumn = column;

			var upList = GetUpNext(tarrifs, ref row, column);
			foreach (var up in upList)
			{
				if (up.Equals(previous))
					break;

				var upLoop = Next(tarrifs, row, column, up, tarrifs[originalRow, originalColumn], loop);
				if (upLoop != null)
					return upLoop;
			}

			row = originalRow;
			column = originalColumn;

			var rightList = GetRightNext(tarrifs, row, ref column);
			foreach (var right in rightList)
			{
				if (right.Equals(previous))
					break;

				var rightLoop = Next(tarrifs, row, column, right, tarrifs[originalRow, originalColumn], loop);
				if (rightLoop != null)
					return rightLoop;

			}

			row = originalRow;
			column = originalColumn;

			var downList = GetDownNext(tarrifs, ref row, column);
			foreach (var down in downList)
			{
				if (down.Equals(previous))
					break;

				var downLoop = Next(tarrifs, row, column, down, tarrifs[originalRow, originalColumn], loop);
				if (downLoop != null)
					return downLoop;

			}

			row = originalRow;
			column = originalColumn;

			var leftList = GetLeftNext(tarrifs, row, ref column);
			foreach (var left in leftList)
			{
				if (left.Equals(previous))
					break;

				var leftLoop = Next(tarrifs, row, column, left, tarrifs[originalRow, originalColumn], loop);
				if (leftLoop != null)
					return leftLoop;
			}

			return null;
		}

		private static List<Tarrif> Next(Tarrifs tarrifs, int row, int column, Tarrif ts, Tarrif previous, List<Tarrif> loop)
		{
			if (ts.Equals(endAndStartLoopTarrif) && loop.Count != 1)
				return loop;

			var newLoop = new List<Tarrif>();
			newLoop.AddRange(loop);
			newLoop.Add(ts);

			return FindNextValueOfLoop(tarrifs, row, column, previous, newLoop);
		}

		private static List<Tarrif> GetUpNext(Tarrifs tarrifs, ref int row, int column)
		{
			for (int i = row - 1; i > -1; --i)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[i, column]))
					return new List<Tarrif> { tarrifs[i, column] };
			}

			var result = new List<Tarrif>();
			for (int i = row - 1; i > -1; --i)
			{
				if (tarrifs[i, column].HasProduct)
				{
					row = i;
					result.Add(tarrifs[i, column]);
				}
			}
			return result;
		}

		private static List<Tarrif> GetRightNext(Tarrifs tarrifs, int row, ref int column)
		{
			for (int j = column + 1; j < tarrifs.NumberOfColumns; ++j)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[row, j]))
					return new List<Tarrif> { tarrifs[row, j] };
			}

			var result = new List<Tarrif>();
			for (int j = column + 1; j < tarrifs.NumberOfColumns; ++j)
			{
				if (tarrifs[row, j].HasProduct)
				{
					column = j;
					result.Add(tarrifs[row, j]);
				}
			}
			return result;
		}

		private static List<Tarrif> GetDownNext(Tarrifs tarrifs, ref int row, int column)
		{
			for (int i = row + 1; i < tarrifs.NumberOfRows; ++i)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[i, column]))
					return new List<Tarrif> { tarrifs[i, column] };
			}

			var result = new List<Tarrif>();
			for (int i = row + 1; i < tarrifs.NumberOfRows; ++i)
			{
				if (tarrifs[i, column].HasProduct)
				{
					row = i;
					result.Add(tarrifs[i, column]);
				}
			}
			return result;
		}


		private static List<Tarrif> GetLeftNext(Tarrifs tarrifs, int row, ref int column)
		{
			for (int j = column - 1; j > -1; --j)
			{
				if (endAndStartLoopTarrif.Equals(tarrifs[row, j]))
					return new List<Tarrif> { tarrifs[row, j] };
			}

			var result = new List<Tarrif>();
			for (int j = column - 1; j > -1; --j)
			{
				if (tarrifs[row, j].HasProduct)
				{
					column = j;
					result.Add(tarrifs[row, j]);
				}
			}
			return result;
		}
	}
}
