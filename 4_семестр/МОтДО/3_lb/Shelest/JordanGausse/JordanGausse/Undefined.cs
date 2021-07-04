namespace JordanGausse
{
	enum NumberOfSolutions
	{ 
		One,
		Many
	}

	class Undefined
	{
		private int id;

		private double coeficient;
		protected double solution;
		protected NumberOfSolutions solutions;

		public double Coeficient { get => coeficient; set => coeficient = value; }

		public double Solution
		{
			get
			{
				return solution;
			}
			set
			{
				if (isManySolutions())
				{
					solutions = NumberOfSolutions.One;
					solution = value;
				}
			}
		}

		public Undefined(int id, double coeficient)
		{
			this.id = id;
			this.coeficient = coeficient;
			this.solutions = NumberOfSolutions.Many;
		}

		protected Undefined(int id, double coeficient, double solution)
		{
			this.id = id;
			this.coeficient = coeficient;
			this.solution = solution;
			this.solutions = NumberOfSolutions.One;
		}

		public Undefined(Undefined other)
		{
			this.id = other.id;
			this.coeficient = other.coeficient;
			this.solutions = other.solutions;
			if (other.isOneSolutions())	{ this.solution = other.solution; }
		}

		public override string ToString()
		{
			string str = "";
			str = coeficient != 1 ? ("(" + coeficient + ")") : "";	
			return str + "x" + id;
		}

		public bool isManySolutions()
		{
			return solutions == NumberOfSolutions.Many;
		}

		public bool isOneSolutions()
		{
			return solutions == NumberOfSolutions.One;
		}

		public override bool Equals(object obj)
		{
			if (this == obj) { return true; }

			return obj != null &&
				this.GetType() == obj.GetType() &&
				this.id == ((Undefined)obj).id;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
