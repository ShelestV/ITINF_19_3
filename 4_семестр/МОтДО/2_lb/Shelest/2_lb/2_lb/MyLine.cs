using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public MyLine(Point A, Point B)
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

		public bool IsPointOnLine(Point point)
		{
			return ((a * point.X) + (b * point.Y)) == c;
		}

		public bool IsPointUnderOrOnLine(Point point)
		{
			return ((a * point.X) + (b * point.Y)) <= c;
		}

		public Point GetIntersectPoint(MyLine line)
		{
			double x = ((this.b * line.c) - (this.c * line.b)) / ((this.a * line.b) - (this.b * line.a));
			double y = -((this.a * x) + this.c) / (this.b);
			return new Point(x, y);
		}

		public bool IsIntersect(MyLine line)
		{
			return this.a != line.a;
		}
	}
}
