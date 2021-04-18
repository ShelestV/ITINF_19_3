using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2_lb
{
	class Graphic : IGraphicDraw, IWorkWithFunctions
	{
		private Grid grid;
		private List<MyLine> functions;

		MyLine leftBorder;
		MyLine rightBorder;
		MyLine topBorder;
		MyLine bottomBorder;

		public Graphic(Grid grid)
		{
			functions = new List<MyLine>();
			this.grid = grid;
			DrawCoordinates();
			DrawLine(new MyLine(0, -1, 0)); // y >= 0
			DrawLine(new MyLine(-1, 0, 0)); // x >= 0

			var leftTopPoint = new MyPoint(-1, Converter.PixelToCoordinateValueForY(0, grid.Height));
			var leftBottomPoint = new MyPoint(-1, -1);
			var rightTopPoint = new MyPoint(Converter.PixelToCoordinateValueForX(grid.Width), Converter.PixelToCoordinateValueForY(0, grid.Height));
			var rightBottomPoint = new MyPoint(Converter.PixelToCoordinateValueForX(grid.Width), -1);

			leftBorder = new MyLine(leftTopPoint, leftBottomPoint);
			rightBorder = new MyLine(rightTopPoint, rightBottomPoint);
			topBorder = new MyLine(leftTopPoint, rightTopPoint);
			bottomBorder = new MyLine(leftBottomPoint, rightBottomPoint);
		}

		public void DrawCoordinates()
		{
			// OX
			this.grid.Children.Add(new Line { X1 = 0, Y1 = grid.Height - Converter.CoordinateValueUnit, X2 = grid.Width, Y2 = grid.Height - Converter.CoordinateValueUnit, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = grid.Width - 15, Y1 = grid.Height - Converter.CoordinateValueUnit - 5, X2 = grid.Width, Y2 = grid.Height - Converter.CoordinateValueUnit, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = grid.Width - 15, Y1 = grid.Height - Converter.CoordinateValueUnit + 5, X2 = grid.Width, Y2 = grid.Height - Converter.CoordinateValueUnit, Stroke = Brushes.LawnGreen });

			// OY
			this.grid.Children.Add(new Line { X1 = Converter.CoordinateValueUnit, Y1 = 0, X2 = Converter.CoordinateValueUnit, Y2 = grid.Height, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = Converter.CoordinateValueUnit + 5, Y1 = 15, X2 = Converter.CoordinateValueUnit, Y2 = 0, Stroke = Brushes.LawnGreen });
			this.grid.Children.Add(new Line { X1 = Converter.CoordinateValueUnit - 5, Y1 = 15, X2 = Converter.CoordinateValueUnit, Y2 = 0, Stroke = Brushes.LawnGreen });
		}

		public void DrawLine(double x1, double y1, double x2, double y2)
		{
			var A = new MyPoint(x1, y1);
			var B = new MyPoint(x2, y2);
			var line = new MyLine(A, B);
			DrawLine(line);
		}

		public void DrawLine(MyLine line)
		{
			functions.Add(line);
			DrawLineWithoutAdding(line);
		}

		public void DrawLineWithoutAdding(MyLine line)
		{
			List<MyPoint> intersectPoints = new List<MyPoint>();

			var lineIntersectLeftBorder = line.GetIntersectPoint(leftBorder);
			var lineIntersectRightBorder = line.GetIntersectPoint(rightBorder);
			var lineIntersectTopBorder = line.GetIntersectPoint(topBorder);
			var lineIntersectBottomBorder = line.GetIntersectPoint(bottomBorder);

			if (Rules.IsWithinOnGridWidthWithConvertToPixel(lineIntersectLeftBorder.X, grid.Width) &&
				Rules.IsWithinOnGridHeigthWithConvertToPixel(lineIntersectLeftBorder.Y, grid.Height))
			{
				intersectPoints.Add(lineIntersectLeftBorder);
			}
			if (Rules.IsWithinOnGridWidthWithConvertToPixel(lineIntersectRightBorder.X, grid.Width) &&
				Rules.IsWithinOnGridHeigthWithConvertToPixel(lineIntersectRightBorder.Y, grid.Height))
			{
				intersectPoints.Add(lineIntersectRightBorder);
			}
			if (Rules.IsWithinOnGridWidthWithConvertToPixel(lineIntersectTopBorder.X, grid.Width) &&
				Rules.IsWithinOnGridHeigthWithConvertToPixel(lineIntersectTopBorder.Y, grid.Height))
			{
				intersectPoints.Add(lineIntersectTopBorder);
			}
			if (Rules.IsWithinOnGridWidthWithConvertToPixel(lineIntersectBottomBorder.X, grid.Width) &&
				Rules.IsWithinOnGridHeigthWithConvertToPixel(lineIntersectBottomBorder.Y, grid.Height))
			{
				intersectPoints.Add(lineIntersectBottomBorder);
			}

			DistinctPoints(intersectPoints);
			if (intersectPoints.Count == 2)
			{

				this.grid.Children.Add(new Line
				{
					X1 = Converter.CoordinateValueToPixelForX(intersectPoints[0].X),
					Y1 = Converter.CoordinateValueToPixelForY(intersectPoints[0].Y, grid.Height),
					X2 = Converter.CoordinateValueToPixelForX(intersectPoints[1].X),
					Y2 = Converter.CoordinateValueToPixelForY(intersectPoints[1].Y, grid.Height),
					Stroke = Brushes.LawnGreen
				});
			}
		}

		private void DistinctPoints(List<MyPoint> points)
		{
			for (int i = 0; i < points.Count; ++i)
			{
				int previousIndex = 0;
				if (i != 0) 
				{ 
					previousIndex = i - 1; 
				}

				while (points.Where(p => p.Equals(points[i])).Count() > 1)
				{
					points.Remove(points[i]);
				}

				if (i >= points.Count)
				{
					i = previousIndex;
				}
			}
		}

		public bool IsWithinAreaFormedByGraphics(MyPoint point)
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
