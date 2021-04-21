using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JordanGausse
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int numberOfUndefineds;
		private int numberOfEquations;

		public MainWindow()
		{
			InitializeComponent();

			/*var equations = new List<Equation>
			{
				new Equation(new List<Undefined> { new Undefined(1, 2), new Undefined(2, -1), new Undefined(3, 1), new Undefined(4, 2), new Undefined(5, 3) }, new FreeValue(6, 2)),
				new Equation(new List<Undefined> { new Undefined(1, 6), new Undefined(2, -3), new Undefined(3, 2), new Undefined(4, 4), new Undefined(5, 5) }, new FreeValue(6, 3)),
				new Equation(new List<Undefined> { new Undefined(1, 6), new Undefined(2, -3), new Undefined(3, 4), new Undefined(4, 8), new Undefined(5, 13) }, new FreeValue(6, 9)),
				new Equation(new List<Undefined> { new Undefined(1, 4), new Undefined(2, -2), new Undefined(3, 1), new Undefined(4, 1), new Undefined(5, 2) }, new FreeValue(6, 1)),
			};

			var gausse = new JordaneGausse(equations);
			gausse.Operate();
			MessageBox.Show(Equation.SolutionString(equations[0].Undefineds.Count) + gausse.ToString());*/
		}

		private TextBox GetTextBox(double marginWidth, double marginHeight)
		{
			TextBox textBox = new TextBox();
			textBox.Foreground = Brushes.LawnGreen;
			textBox.Background = Brushes.Black;
			textBox.FontSize = 14;
			textBox.TextAlignment = TextAlignment.Right;
			textBox.Width = 20;
			textBox.Height = 20;
			textBox.VerticalAlignment = VerticalAlignment.Top;
			textBox.HorizontalAlignment = HorizontalAlignment.Left;
			textBox.BorderThickness = new Thickness(1);
			textBox.BorderBrush = Brushes.LawnGreen;
			textBox.Margin = new Thickness(marginWidth, marginHeight, 0, 0);
			return textBox;
		}

		private Label GetLabel(string content, double marginLeft, double marginTop)
		{
			Label label = new Label();
			label.Content = content;
			label.FontSize = 16;
			label.VerticalContentAlignment = VerticalAlignment.Center;
			label.HorizontalContentAlignment = HorizontalAlignment.Center;
			label.Foreground = Brushes.LawnGreen;
			label.VerticalAlignment = VerticalAlignment.Top;
			label.HorizontalAlignment = HorizontalAlignment.Left;
			label.Margin = new Thickness(marginLeft, marginTop, 0, 0);
			return label;
		}

		private void GetInputEquationTableButton_Click(object sender, RoutedEventArgs e)
		{
			if (InputRules.IsCorrectUnsignedInt(NumberOfUndefinedsTextBox.Text, out numberOfUndefineds) &&
				InputRules.IsCorrectUnsignedInt(NumberOfEqationsTextBox.Text, out numberOfEquations))
			{
				for (int i = 0; i < numberOfEquations; ++i)
				{
					EquationsGrid.Children.Add(GetTextBox(5, i * 30));
					EquationsGrid.Children.Add(GetLabel("x1", 25, i * 30 - 5));
					for (int j = 1; j < numberOfUndefineds; ++j)
					{
						EquationsGrid.Children.Add(GetLabel("+", 60 * j - 15, i * 30 - 5));
						EquationsGrid.Children.Add(GetTextBox(20 + 60 * j - 15, i * 30));
						EquationsGrid.Children.Add(GetLabel("x" + (j + 1).ToString(), 40 + 60 * j - 15, i * 30 - 5));
					}
					EquationsGrid.Children.Add(GetLabel("=", 60 * numberOfUndefineds - 15, i * 30 - 5));
					EquationsGrid.Children.Add(GetTextBox(20 + 60 * numberOfUndefineds - 15, i * 30));
				}

				CalculateByJordaneGaussMethodButton.Visibility = Visibility.Visible;
			}

			NumberOfUndefinedsTextBox.Text = "";
			NumberOfEqationsTextBox.Text = "";
		}

		private void CalculateByJordaneGaussMethodButton_Click(object sender, RoutedEventArgs e)
		{
			int indexOfUndefined = 0;
			int indexOfEquation = 0;

			List<Equation> equations = new List<Equation>();
			List<List<Undefined>> undefineds = new List<List<Undefined>>();

			for (int i = 0; i < numberOfEquations; ++i)
			{
				undefineds.Add(new List<Undefined>());
			}

			foreach (var component in EquationsGrid.Children)
			{
				if (component.GetType() == NumberOfEqationsTextBox.GetType())
				{
					int number;
					if (!InputRules.IsCorrectInt(((TextBox)component).Text, out number))
					{
						MessageBox.Show("Input correct values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}

					if (indexOfUndefined != numberOfUndefineds)
					{
						undefineds[indexOfEquation].Add(new Undefined(indexOfUndefined + 1, number));
						++indexOfUndefined;
					}
					else if (indexOfUndefined == numberOfUndefineds)
					{
						equations.Add(new Equation(undefineds[indexOfEquation], new FreeValue(indexOfUndefined + 1, number)));
						indexOfUndefined = 0;
						++indexOfEquation;
					}
				}
			}

			var jordaneGausse = new JordaneGausse(equations);
			jordaneGausse.Operate();
			MessageBox.Show(Equation.SolutionString(equations[0].Undefineds.Count) + jordaneGausse.ToString());
		}
	}
}
