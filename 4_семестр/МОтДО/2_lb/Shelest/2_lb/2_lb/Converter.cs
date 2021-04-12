using System;

namespace _2_lb
{
	class Converter
	{
		public static double CoordinateValueUnit { get => 50; }
		public static double InputCoefficientToDouble(string input)
		{
			double coefficient;

			try
			{
				coefficient = Convert.ToDouble(input);
			}
			catch (FormatException)
			{
				coefficient = 1.0;
			}

			return coefficient;
		}

		public static double CoordinateValueToPixelForX(double coordinateX)
		{
			return (coordinateX + 1) * CoordinateValueUnit;
		}

		public static double PixelToCoordinateValueForX(double pixelX)
		{
			return (pixelX / CoordinateValueUnit) - 1;
		}

		public static double CoordinateValueToPixelForY(double coordinateY, double heigth)
		{
			return heigth - ((coordinateY + 1) * CoordinateValueUnit);
		}

		public static double PixelToCoordinateValueForY(double pixelY, double heigth)
		{
			return ((heigth - pixelY) / CoordinateValueUnit) - 1;
		}
	}
}
