using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2_lb
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Graphic graphic;
		MyLine ZFunction;
		double Z;
		public MainWindow()
		{
			InitializeComponent();

			graphic = new Graphic(GraphicGrid);
		}

		private void AddZFunctionButton_Click(object sender, RoutedEventArgs e)
		{
			double a;
			double b;

			a = Converter.InputCoefficientToDouble(Zx1TextBox.Text);
			b = Converter.InputCoefficientToDouble(Zx2TextBox.Text);

			if (a == 0 && b == 0)
			{
				MessageBox.Show("Нельзя будет построить график функции!\nВведите другие значения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				//Random rand = new Random();
				//double c = rand.Next(0, (int)Converter.PixelToCoordinateValueForX(GraphicGrid.Width));
				Z = 0;
				ZFunction = new MyLine(a, b, Z);
			}

			Zx1TextBox.Text = "";
			Zx2TextBox.Text = "";
		}

		private void AddFunctionButton_Click(object sender, RoutedEventArgs e)
		{
			double a;
			double b;
			double c;

			a = Converter.InputCoefficientToDouble(FunctionATextBox.Text);
			b = Converter.InputCoefficientToDouble(FunctionBTextBox.Text);
			c = Converter.InputCoefficientToDouble(FunctionCTextBox.Text);
			
			var function = new MyLine(a, b, -c);
			graphic.DrawLine(function);

			FunctionATextBox.Text = "";
			FunctionBTextBox.Text = "";
			FunctionCTextBox.Text = "";
		}

		private void FillIntersectArea_Click(object sender, RoutedEventArgs e)
		{
			if (ZFunction.Equals(new MyLine(0, 0, 0)))
			{
				MessageBox.Show("Введите Z функцию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			double maxDistanceToTopPoint = 0;
			double maxDistanceToBottomPoint = 0;

			MyPoint topPoint = new MyPoint();
			MyPoint bottomPoint = new MyPoint();

			bool isFoundTopPoint = false;
			bool isFoundBottomPoint = false;

			for (double i = Converter.CoordinateValueUnit; i < GraphicGrid.Height; ++i)
			{
				for (double j = Converter.CoordinateValueUnit; j < GraphicGrid.Width; ++j)
				{
					double x = Math.Round(Converter.PixelToCoordinateValueForX(j) * 1000) / 1000;
					double y = Math.Round(Converter.PixelToCoordinateValueForY(i, GraphicGrid.Height) * 1000) / 1000;

					MyPoint point = new MyPoint(x, y);

					if (graphic.IsWithinAreaFormedByGraphics(point))
					{
						Line drawPoint = new Line { X1 = j - 1, Y1 = i - 1, X2 = j + 1, Y2 = i + 1, Stroke = Brushes.Green };
						GraphicGrid.Children.Add(drawPoint);

						double distance = ZFunction.CalculateDistanceToPoint(point);
						if (ZFunction.IsPointUnderOrOnLine(point))
						{
							if (maxDistanceToBottomPoint < distance) 
							{ 
								maxDistanceToBottomPoint = distance;
								bottomPoint = point;
								isFoundBottomPoint = true;
							}
						}
						else
						{
							if (maxDistanceToTopPoint < distance)
							{
								maxDistanceToTopPoint = distance;
								topPoint = point;
								isFoundTopPoint = true;
							}
						}
					}
				}
			}

			graphic.DrawLineWithoutAdding(ZFunction);

			StringBuilder message = new StringBuilder();
			#region Fill message
			message.Append("Z = ");
			message.Append(Z);
			message.Append(Environment.NewLine);
			if (isFoundTopPoint)
			{
				message.Append("Наибольшее значение функции Z находится в точке (");
				message.Append(topPoint.X);
				message.Append(", ");
				message.Append(topPoint.Y);
				message.Append(")");
				message.Append(Environment.NewLine);
			}
			else
			{
				message.Append("Не удалось найти наибольшее значение функции Z");
				message.Append(Environment.NewLine);
			}

			if (isFoundBottomPoint)
			{
				message.Append("Наименьшее значение функции Z находится в точке (");
				message.Append(bottomPoint.X);
				message.Append(", ");
				message.Append(bottomPoint.Y);
				message.Append(")");
			}
			else
			{
				message.Append("Не удалось найти наименьшее значение функции Z");
			}
			#endregion
			MessageBox.Show(message.ToString());
		}
	}
}
