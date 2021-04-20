using System.Collections.Generic;
using System.Windows;

namespace JordanGausse
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var equations = new List<Equation>
			{
				new Equation(new List<Undefined> { new Undefined(1, 2), new Undefined(2, -1), new Undefined(3, 1), new Undefined(4, 2), new Undefined(5, 3) }, new FreeValue(6, 2)),
				new Equation(new List<Undefined> { new Undefined(1, 6), new Undefined(2, -3), new Undefined(3, 2), new Undefined(4, 4), new Undefined(5, 5) }, new FreeValue(6, 3)),
				new Equation(new List<Undefined> { new Undefined(1, 6), new Undefined(2, -3), new Undefined(3, 4), new Undefined(4, 8), new Undefined(5, 13) }, new FreeValue(6, 9)),
				new Equation(new List<Undefined> { new Undefined(1, 4), new Undefined(2, -2), new Undefined(3, 1), new Undefined(4, 1), new Undefined(5, 2) }, new FreeValue(6, 1)),
			};

			var gausse = new JordaneGausse(equations);
			gausse.Operate();
			MessageBox.Show(Equation.SolutionString() + gausse.ToString());
		}
	}
}
