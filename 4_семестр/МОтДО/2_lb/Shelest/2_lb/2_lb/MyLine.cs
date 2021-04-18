using System;

namespace _2_lb
{
	struct MyLine
	{
		private double a;
		private double b;
		private double c;

		public MyLine(double cofBeforeX1, double cofBeforeX2, double cofAfterCompareSymbol)
		{
			a = cofBeforeX1;
			b = cofBeforeX2;
			c = cofAfterCompareSymbol;
		}

		public MyLine(MyPoint A, MyPoint B)
		{
			a = A.Y - B.Y;
			b = B.X - A.X;
			c = (A.X * B.Y) - (B.X * A.Y);
		}

		public double GetX(double y)
		{
			return (c - (b * y)) / a;
		}

		public double GetY(double x)
		{
			return (c - (a * x)) / b;
		}

		public bool IsPointOnLine(MyPoint point)
		{
			return ((a * point.X) + (b * point.Y)) == c;
		}

		public bool IsPointUnderOrOnLine(MyPoint point)
		{
			return ((a * point.X) + (b * point.Y)) + c <= 0;
		}

		public MyPoint GetIntersectPoint(MyLine line)
		{
			double x = ((this.b * line.c) - (this.c * line.b)) / ((this.a * line.b) - (this.b * line.a));
			double y = -((this.a * x) + this.c) / (this.b);
			return new MyPoint(x, y);
		}

		public bool IsIntersect(MyLine line)
		{
			return this.a != line.a;
		}

		public double CalculateDistanceToPoint(MyPoint point)
		{
			return Math.Abs((a * point.X) + (b * point.Y) + c) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}

		public override bool Equals(object obj)
		{
			return obj is MyLine line &&
				   a == line.a &&
				   b == line.b &&
				   c == line.c;
		}

		public override int GetHashCode()
		{
			int hashCode = 1474027755;
			hashCode = hashCode * -1521134295 + a.GetHashCode();
			hashCode = hashCode * -1521134295 + b.GetHashCode();
			hashCode = hashCode * -1521134295 + c.GetHashCode();
			return hashCode;
		}
	}
}
