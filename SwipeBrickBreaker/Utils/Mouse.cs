using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace SwipeBrickBreaker.Utils
{
	public class Mouse
	{
		private Point Position;
		public Vector2 GetPosition
		{
			get { return new Vector2((float)Position.X, (float)Position.Y); }
		}


		public Mouse()
		{
			Position.X = Position.Y = 0;
		}

		public void SetPosition(double x, double y)
		{
			Position.X = x;
			Position.Y = y;
		}

		public void SetPosition(Vector2 vector)
		{
			this.SetPosition(vector.X, vector.Y);
		}

		public void SetPosition(Point point)
		{
			SetPosition(point.X, point.Y);
		}
	}

	public struct Drager
	{
		public readonly Point StartPosition;
		public Point CurentPosition { get; }

		public Drager(Point start)
		{
			this.StartPosition = new Point(start.X, start.Y);
			this.CurentPosition = new Point(start.X, start.Y);
		}

		//public Drager
	}
}
