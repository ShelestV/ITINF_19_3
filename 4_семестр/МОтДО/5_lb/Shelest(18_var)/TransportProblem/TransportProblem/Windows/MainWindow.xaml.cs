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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TransportProblem.Models;
using TransportProblem.Windows;

namespace TransportProblem
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void PotentialMethodButton_Click(object sender, RoutedEventArgs e)
		{

			var pmMethod = new PotentialMethodWindow(this);
			pmMethod.Show();
			this.Hide();


			/*var warehouses = new Warehouses(3);
			warehouses[0] = 40;
			warehouses[1] = 30;
			warehouses[2] = 35;

			var clients = new Clients(5);
			clients[0] = 20;
			clients[1] = 34;
			clients[2] = 16;
			clients[3] = 10;
			clients[4] = 15;

			var tarrifs = new Tarrifs(warehouses.Count, clients.Count);
			tarrifs[0, 0] = new Tarrif(2, 0, 0);
			tarrifs[0, 1] = new Tarrif(6, 0, 1);
			tarrifs[0, 2] = new Tarrif(3, 0, 2);
			tarrifs[0, 3] = new Tarrif(4, 0, 3);
			tarrifs[0, 4] = new Tarrif(8, 0, 4);
			tarrifs[1, 0] = new Tarrif(1, 1, 0);
			tarrifs[1, 1] = new Tarrif(5, 1, 1);
			tarrifs[1, 2] = new Tarrif(6, 1, 2);
			tarrifs[1, 3] = new Tarrif(9, 1, 3);
			tarrifs[1, 4] = new Tarrif(7, 1, 4);
			tarrifs[2, 0] = new Tarrif(3, 2, 0);
			tarrifs[2, 1] = new Tarrif(4, 2, 1);
			tarrifs[2, 2] = new Tarrif(1, 2, 2);
			tarrifs[2, 3] = new Tarrif(6, 2, 3);
			tarrifs[2, 4] = new Tarrif(10, 2, 4);

			var tp = new TransportationProblem(tarrifs, warehouses, clients);
			tp.GetOptimalPlan();*/
		}

		private void AssignmentProblemButton_Click(object sender, RoutedEventArgs e)
		{

		}



	}
}
