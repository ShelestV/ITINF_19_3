using System;
using System.Collections.Generic;
using System.Text;

namespace JordanGausse
{
	class Equation
	{
		private static List<Undefined> solutions;

		private List<Undefined> undefineds;
		private FreeValue freeValue;

		public FreeValue Free { get => freeValue; }
		public List<Undefined> Undefineds { get => undefineds; }
		public Undefined GetUndefinedByIndex(int index)
		{
			return undefineds[index];
		}

		public Equation(List<Undefined> undefineds, FreeValue freeValue)
		{
			solutions = new List<Undefined>();
			this.undefineds = new List<Undefined>();
			foreach (var x in undefineds)
			{
				this.undefineds.Add(new Undefined(x));
			}
			this.freeValue = new FreeValue(freeValue);
		}

		public void ChangeCoeficientToElementByIndex(double coeficient, int index)
		{
			undefineds[index].Coeficient = coeficient;
		}

		public void DeleteOnElement(double element)
		{
			undefineds.ForEach(x => x.Coeficient /= element);
			freeValue.Coeficient /= element;
		}
		
		public static Equation SolveSolution(Equation equation)
		{
			DeleteUndefinedsWithNullCoeficient(equation);
			Equation result = Equation.CopyEquation(equation);

			double freeValue = equation.freeValue.Coeficient;

			int indexNotZero = GetNotZeroIndex(equation);
			if (indexNotZero != -1)
			{
				//equation.undefineds[indexNotZero].Solution = freeValue / equation.undefineds[indexNotZero].Coeficient;
				result.undefineds[indexNotZero].Solution = freeValue / equation.undefineds[indexNotZero].Coeficient;
				//AddToSolutionIfDoesNotExist(equation.undefineds[indexNotZero]);
				AddToSolutionIfDoesNotExist(result.undefineds[indexNotZero]);
			}
			return result;
		}

		public static Equation CopyEquation(Equation equation)
		{
			return new Equation(equation.Undefineds, equation.Free);
		}

		private static void DeleteUndefinedsWithNullCoeficient(Equation equation)
		{
			equation.undefineds.RemoveAll(x => x.Coeficient == 0);
		}

		private static int GetNotZeroIndex(Equation equation)
		{
			int indexNotZero = -1;
			int countNotZero = 0;
			for (int i = 0; i < equation.undefineds.Count; ++i)
			{
				if (equation.undefineds[i].Coeficient != 0 &&
					equation.undefineds[i].isManySolutions())
				{
					++countNotZero;
					indexNotZero = i;
				}
			}
			return countNotZero <= 1 ? indexNotZero : -1; 
		}

		private static void AddToSolutionIfDoesNotExist(Undefined undefine)
		{
			foreach (var x in solutions)
			{
				if (x.Equals(undefine))	{ return; }
			}
			solutions.Add(undefine);
		}
		public static string SolutionString(int numberOfUndefineds)
		{
			StringBuilder sb = new StringBuilder();
			if (solutions.Count != numberOfUndefineds)
			{
				sb.Append("Have many solutions, but always: ");
				sb.Append(Environment.NewLine);
			}

			foreach (var solution in solutions)
			{
				sb.Append(solution.ToString());
				sb.Append(" = ");
				sb.Append(solution.Solution);
				sb.Append(Environment.NewLine);
			}
			sb.Append(Environment.NewLine);
			return sb.ToString();
		}

		public override string ToString()
		{
			if (undefineds.Count == 0) { return ""; }

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < undefineds.Count; ++i)
			{
				sb.Append(undefineds[i].ToString());
				sb.Append((i == undefineds.Count - 1) ? " = " : " + ");
			}
			sb.Append(freeValue.ToString());
			return sb.ToString();
		}
	}
}
