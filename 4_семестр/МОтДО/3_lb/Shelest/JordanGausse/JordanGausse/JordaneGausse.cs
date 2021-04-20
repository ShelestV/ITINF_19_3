using System;
using System.Collections.Generic;
using System.Text;

namespace JordanGausse
{
	class JordaneGausse
	{
		private List<Equation> originalEquations;
		private List<Equation> copyEquations;
		private List<Equation> resultEquation;

		public List<Equation> OriginalEquations { get => originalEquations; }
		public List<Equation> ResultEquations { get => copyEquations; }
		public List<Equation> Solutions { get => resultEquation; }

		public JordaneGausse(List<Equation> originalEquations)
		{
			this.originalEquations = originalEquations;
			this.copyEquations = CopyEquations(originalEquations);
			resultEquation = new List<Equation>();
		}

		private List<Equation> CopyEquations(List<Equation> equations)
		{
			var result = new List<Equation>();
			equations.ForEach(e => result.Add(Equation.CopyEquation(e)));
			return result;
		}

		public void Operate()
		{
			for (int i = 0; i < copyEquations.Count; ++i)
			{
				if (copyEquations[i].Undefineds[i].Coeficient != 0)
				{
					CalculateBySolvedElement(i);
				}
			}
			SolveSolutions();
		}

		private void CalculateBySolvedElement(int indexOfSolvedElement)
		{
			var result = CopyEquations(copyEquations);

			SetNullsToColumn(result, indexOfSolvedElement);
			CalculateEquationWithSolvedElement(result, indexOfSolvedElement);
			CalculateOtherElements(result, indexOfSolvedElement);

			copyEquations = result;
		}

		private void SetNullsToColumn(List<Equation> equations, int indexOfSolvedElement)
		{
			for (int i = 0; i < copyEquations.Count; ++i)
			{
				if (i != indexOfSolvedElement)
				{
					equations[i].ChangeCoeficientToElementByIndex(0, indexOfSolvedElement);
				}
			}
		}

		private void CalculateEquationWithSolvedElement(List<Equation> equations, int indexOfSolvedElement)
		{
			var equation = equations[indexOfSolvedElement];
			double deleteElement = copyEquations[indexOfSolvedElement].GetUndefinedByIndex(indexOfSolvedElement).Coeficient;
			equation.DeleteOnElement(deleteElement);
		}

		private void CalculateOtherElements(List<Equation> equations, int indexOfSolvedElement)
		{
			for (int i = 0; i < copyEquations.Count; ++i)
			{
				if (i == indexOfSolvedElement) { continue;	}

				for (int j = 0; j < copyEquations[i].Undefineds.Count; ++j)
				{
					if (j == indexOfSolvedElement) { continue; }

					equations[i].Undefineds[j].Coeficient = NewOtherElementCoeficient(indexOfSolvedElement, i, j);
				}

				equations[i].Free.Coeficient = NewFreeElement(indexOfSolvedElement, i);
			}
		}

		private double NewOtherElementCoeficient(int indexOfSolvedElement, int i, int j)
		{
			double a = copyEquations[indexOfSolvedElement].Undefineds[j].Coeficient;
			double b = copyEquations[i].Undefineds[indexOfSolvedElement].Coeficient;

			double xRS = copyEquations[indexOfSolvedElement].Undefineds[indexOfSolvedElement].Coeficient;
			
			return copyEquations[i].Undefineds[j].Coeficient - ((a * b) / xRS);
		}

		private double NewFreeElement(int indexOfSolvedElement, int i)
		{
			double a = copyEquations[indexOfSolvedElement].Free.Coeficient;
			double b = copyEquations[i].Undefineds[indexOfSolvedElement].Coeficient;

			double xRS = copyEquations[indexOfSolvedElement].Undefineds[indexOfSolvedElement].Coeficient;

			return copyEquations[i].Free.Coeficient - ((a * b) / xRS);
		}

		private void SolveSolutions()
		{
			foreach (var equation in copyEquations)
			{
				resultEquation.Add(Equation.SolveSolution(equation));
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			resultEquation.ForEach(resEq =>
			{
				if (resEq.ToString() != "")
				{
					sb.Append(resEq.ToString());
					sb.Append(Environment.NewLine);
				}
			});
			return sb.ToString();
		}
	}
}
