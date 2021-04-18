namespace _2_lb
{
	struct MyPoint
	{
		public double X { get; }
		public double Y { get; }

		public MyPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public override bool Equals(object obj)
		{
			return obj is MyPoint point &&
				   X == point.X &&
				   Y == point.Y;
		}

		public override int GetHashCode()
		{
			int hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}
	}
}
