using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TransportProblem.Rools;
using TransportProblem.Models;

namespace TransportProblem.Windows
{
	/// <summary>
	/// Логика взаимодействия для PotentialMethod.xaml
	/// </summary>
	public partial class PotentialMethodWindow : Window
	{
		private int numberOfRows;
		private int numberOfColumns;

		private List<List<TextBox>> transportProblemTextBoxes;

		private Window previousWindow;

		public PotentialMethodWindow(Window previous)
		{
			InitializeComponent();

			previousWindow = previous;
			transportProblemTextBoxes = new List<List<TextBox>>();
		}

		private void GetTransportProblemTableButton_Click(object sender, RoutedEventArgs e)
		{
			if (Rool.IsCorrectUnsignedInt(RowsTextBox.Text, out numberOfRows) &&
				Rool.IsCorrectUnsignedInt(ColumnsTextBox.Text, out numberOfColumns))
			{
				for (int i = 0; i < numberOfRows + 1; ++i)
				{
					var row = new RowDefinition();
					GridLength height = new GridLength(30);
					row.Height = height;
					TransportProblemGrid.RowDefinitions.Add(row);
				}

				for (int j = 0; j < numberOfColumns + 1; ++j)
				{
					var column = new ColumnDefinition();
					GridLength width = new GridLength(50);
					column.Width = width;
					TransportProblemGrid.ColumnDefinitions.Add(column);
				}

				for (int i = 0; i < numberOfRows + 1; ++i)
				{
					var row = new List<TextBox>();
					for (int j = 0; j < numberOfColumns + 1; ++j)
					{
						if (i == numberOfRows && j == numberOfColumns)
							continue;
						row.Add(GetTextBox(i, j));

						if (i == numberOfRows || j == numberOfColumns)
							row[j].BorderBrush = Brushes.Aquamarine;
						TransportProblemGrid.Children.Add(row[j]);
					}
					transportProblemTextBoxes.Add(row);
				}

				CalculateOptimalPlanButton.Visibility = Visibility.Visible;
			}

			RowsTextBox.Text = "";
			ColumnsTextBox.Text = "";
		}

		private void CalculateOptimalPlanButton_Click(object sender, RoutedEventArgs e)
		{
			var tarrifs = new Tarrifs(numberOfRows, numberOfColumns);
			var warehouses = new Warehouses(numberOfColumns);
			var clients = new Clients(numberOfColumns);

			for (int i = 0; i < transportProblemTextBoxes.Count; ++i)
			{
				for (int j = 0; j < transportProblemTextBoxes[0].Count; ++j)
				{
					if (i == transportProblemTextBoxes.Count - 1 &&
						j == transportProblemTextBoxes[0].Count - 1)
							continue;

					int value;
					if (!Rool.IsCorrectUnsignedInt(transportProblemTextBoxes[i][j].Text, out value))
						return;

					if (i == transportProblemTextBoxes.Count - 1)
						clients[j] = value;
					else if (j == transportProblemTextBoxes[i].Count - 1)
						warehouses[i] = value;
					else
						tarrifs[i, j] = new Tarrif(value, i, j);
				}
			}

			var tp = new TransportationProblem(tarrifs, warehouses, clients);
			var optimalePlan = tp.GetOptimalPlan();

			for (int i = 0; i < optimalePlan.NumberOfRows; ++i)
			{
				var row = new RowDefinition();
				GridLength height = new GridLength(30);
				row.Height = height;
				ResultGrid.RowDefinitions.Add(row);
			}

			for (int j = 0; j < optimalePlan.NumberOfColumns; ++j)
			{
				var column = new ColumnDefinition();
				GridLength width = new GridLength(50);
				column.Width = width;
				ResultGrid.ColumnDefinitions.Add(column);
			}

			F.Text = optimalePlan.GetF();

			for (int i = 0; i < numberOfRows + 1; ++i)
				for (int j = 0; j < numberOfColumns + 1; ++j)
					ResultGrid.Children.Add(GetTextBlock(optimalePlan[i, j].ToString(), i, j));

			OptimalePlanLabel.Visibility = Visibility.Visible;
		}

		private TextBox GetTextBox(int row, int column)
		{
			TextBox textBox = new TextBox();
			textBox.Style = (Style)textBox.FindResource("BGThemeTextBox");
			textBox.Width = 50;
			textBox.Height = 30;
			Grid.SetRow(textBox, row);
			Grid.SetColumn(textBox, column);
			return textBox;
		}

		private TextBlock GetTextBlock(string text, int row, int column)
		{
			TextBlock textBlock = new TextBlock();
			textBlock.Style = (Style)textBlock.FindResource("BGThemeTextBlock");
			textBlock.Width = 50;
			textBlock.Height = 30;
			textBlock.Text = text;
			textBlock.TextAlignment = TextAlignment.Center;
			return textBlock;
		}

		private Label GetLabel(string content, double marginLeft, double marginTop)
		{
			Label label = new Label();
			label.Style = (Style)label.FindResource("BGThemeLabel");
			label.Content = content;
			label.VerticalContentAlignment = VerticalAlignment.Center;
			label.HorizontalContentAlignment = HorizontalAlignment.Center;
			label.Margin = new Thickness(marginLeft, marginTop, 0, 0);
			return label;
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			previousWindow.Show();
		}
	}
}
