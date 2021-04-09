using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2_lb
{
	class Graphic : IGraphicDraw, IWorkWithFunctions
	{
		private Grid grid;
		private List<MyLine> functions;

		public Graphic(Grid grid)
		{
			functions = new List<MyLine>();
			this.grid = grid;
			DrawCoordinates();
			DrawLine(0, 0, 1, 0); // y >= 0
			DrawLine(0, 0, 0, 1); // x >= 0
		}

		public void DrawCoordinates()
		{
			// OX
			this.grid.Children.Add(new Line { X1 = 0, Y1 = 395, X2 = 400, Y2 = 395, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = 385, Y1 = 390, X2 = 400, Y2 = 395, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = 385, Y1 = 400, X2 = 400, Y2 = 395, Stroke = Brushes.LawnGreen });
			// OY
			this.grid.Children.Add(new Line { X1 = 5, Y1 = 0, X2 = 5, Y2 = 400, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = 10, Y1 = 15, X2 = 5, Y2 = 0, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = 0, Y1 = 15, X2 = 5, Y2 = 0, Stroke = Brushes.LawnGreen });
		}

		public void DrawLine(double x1, double y1, double x2, double y2)
		{
			var A = new Point(x1, y1);
			var B = new Point(x2, y2);
			var line = new MyLine(A, B);
			functions.Add(line);

			var leftTopPoint = new Point(-1, Converter.PixelToCoordinateValueForY(0, grid.Height));
			var leftBottomPoint = new Point(-1, -1);
			var rightTopPoint = new Point(Converter.PixelToCoordinateValueForX(grid.Width), Converter.PixelToCoordinateValueForY(0, grid.Height));
			var rightBottomPoint = new Point(Converter.PixelToCoordinateValueForX(grid.Width), -1);

			var leftBorder = new MyLine(leftTopPoint, leftBottomPoint);
			var rightBorder = new MyLine(rightTopPoint, rightBottomPoint);
			var topBorder = new MyLine(leftTopPoint, rightTopPoint);
			var bottomBorder = new MyLine(leftBottomPoint, rightBottomPoint);

			if (Rules.IsWithinOnGridWidth(line.GetIntersectPoint(leftBorder).X, grid.Width))
			{ 
				
			}

			this.grid.Children.Add(new Line
			{
				X1 = Converter.CoordinateValueToPixelForX(line.GetX(-1)),
				Y1 = Converter.CoordinateValueToPixelForY(line.GetY(-1), grid.Height),
				X2 = Converter.CoordinateValueToPixelForX(line.GetX(Converter.PixelToCoordinateValueForX(grid.Width))),
				Y2 = Converter.CoordinateValueToPixelForY(line.GetY(Converter.PixelToCoordinateValueForY(0, grid.Height)), grid.Height),
				Stroke = Brushes.LawnGreen
			});

		}

		public bool IsWithinAreaFormedByGraphics(Point point)
		{
			foreach (var line in functions)
			{
				if (!line.IsPointUnderOrOnLine(point))
				{
					return false;
				}
			}
			return true;
		}
	}
}
