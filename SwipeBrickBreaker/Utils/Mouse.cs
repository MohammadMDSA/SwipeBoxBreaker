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
		public Point Position { get => _Position; }
		private Point _Position;
		public bool Dragging { get; private set; }
		public Drager Drager { get; private set; }
		public Vector2 GetPosition
		{
			get { return new Vector2((float)_Position.X, (float)_Position.Y); }
		}

		public Mouse()
		{
			_Position.X = _Position.Y = 0;
		}

		public void SetPosition(double x, double y)
		{
			_Position.X = x;
			_Position.Y = y;
			if (Dragging)
				Drager.SetCurentPosition(x, y);
		}

		public void SetPosition(Vector2 vector)
		{
			this.SetPosition(vector.X, vector.Y);
		}

		public void SetPosition(Point point)
		{
			SetPosition(point.X, point.Y);
		}

		public void Press()
		{
			this.Dragging = true;
			Drager = new Drager(this.Position);
		}

		public void Release()
		{
			this.Dragging = false;
			this.Drager = default(Drager);
		}
	}

	public struct Drager
	{
		public readonly Point StartPosition;
		public Point CurentPosition { get => _CurentPosition; }
		private Point _CurentPosition;
		public Vector2 CurentPositionVector { get => _CurentPosition.ToVector2(); }
		public Vector2 StartPositionVector { get => StartPosition.ToVector2(); }

		public Drager(Point start)
		{
			this.StartPosition = new Point(start.X, start.Y);
			this._CurentPosition = new Point(start.X, start.Y);
		}

		public void SetCurentPosition(double x, double y)
		{
			this._CurentPosition.X = x;
			this._CurentPosition.Y = y;
		}
	}
}
