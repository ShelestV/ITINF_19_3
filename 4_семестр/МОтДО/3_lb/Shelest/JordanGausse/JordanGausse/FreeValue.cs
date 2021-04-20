namespace JordanGausse
{
	class FreeValue : Undefined
	{
		public FreeValue(int index, double coeficient) : base(index, coeficient, 1) { }
		public FreeValue(FreeValue value) : base(value) { }

		public override string ToString()
		{
			return Coeficient.ToString();
		}
	}
}
