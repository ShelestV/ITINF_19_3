using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lb
{
	class Converter
	{
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
			return (coordinateX + 1) * 5;
		}

		public static double PixelToCoordinateValueForX(double pixelX)
		{
			return (pixelX / 5) - 1;
		}

		public static double CoordinateValueToPixelForY(double coordinateY, double heigth)
		{
			return heigth - ((coordinateY + 1) * 5);
		}

		public static double PixelToCoordinateValueForY(double pixelY, double heigth)
		{
			return ((heigth - pixelY) / 5) - 1;
		}
	}
}
