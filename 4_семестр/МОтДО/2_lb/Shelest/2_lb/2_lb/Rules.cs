using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


	}
}
