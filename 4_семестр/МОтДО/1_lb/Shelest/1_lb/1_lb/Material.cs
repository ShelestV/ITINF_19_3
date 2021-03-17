namespace _1_lb
{
	class Material
	{
		private int _id;
		private double _stock;

		private int ID
		{
			get => _id;
		}

		public double Stock
		{
			get => _stock;
			set => _stock = value;
		}

		public Material(int index,  double stock)
		{
			_id = index;
			_stock = stock;
		}

		public Material(Material material)
		{
			_id = material._id;
			_stock = material._stock;
		}
	}
}
