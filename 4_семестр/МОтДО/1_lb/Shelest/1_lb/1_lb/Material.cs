namespace _1_lb
{
	public class Material
	{
		private string _name;
		private double _stock;

		public string Name
		{
			get => _name;
			set => _name = value;
		}

		public double Stock
		{
			get => _stock;
			set => _stock = value;
		}

		public Material(string name, double stock)
		{
			_name = name;
			_stock = stock;
		}

		public Material(Material material)
		{
			_name = material.Name;
			_stock = material.Stock;
		}

		public override string ToString()
		{
			return _name + " : stock = " + _stock;
		}
	}
}
