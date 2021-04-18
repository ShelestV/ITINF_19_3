namespace _2_lb
{
	class Rules
	{
		public static bool IsWithinOnGridWidth(double value, double width)
		{
			return 0 <= value && value <= width;
		}

		public static bool IsWithinOnGridHeigth(double value, double heigth)
		{
			return 0 <= value && value <= heigth;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Specified in coordinate value</param>
		/// <param name="width">Specified in pixels</param>
		/// <returns></returns>
		public static bool IsWithinOnGridWidthWithConvertToPixel(double value, double width)
		{
			var valueInPixels = Converter.CoordinateValueToPixelForX(value);
			return 0 <= valueInPixels && valueInPixels <= width;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Specified in coordinate value</param>
		/// <param name="width">Specified in pixels</param>
		/// <returns></returns>
		public static bool IsWithinOnGridHeigthWithConvertToPixel(double value, double heigth)
		{
			var valueInPixels = Converter.CoordinateValueToPixelForY(value, heigth);
			return 0 <= valueInPixels && valueInPixels <= heigth;
		}
	}
}
