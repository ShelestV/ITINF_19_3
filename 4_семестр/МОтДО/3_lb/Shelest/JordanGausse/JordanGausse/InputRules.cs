using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanGausse
{
	class InputRules
	{
		public static bool IsCorrectUnsignedInt(string str, out int number)
		{
			return IsCorrectInt(str, out number) && number > 0;
		}

		public static bool IsCorrectInt(string str, out int number)
		{
			return Int32.TryParse(str, out number);
		}
	}
}
