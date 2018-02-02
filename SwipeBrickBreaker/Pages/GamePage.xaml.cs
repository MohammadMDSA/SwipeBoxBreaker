using Microsoft.Graphics.Canvas.UI.Xaml;
using SwipeBrickBreaker.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SwipeBrickBreaker.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class GamePage : Page
	{
		public Mouse Mouse { get; }
		int temp = 0;

		public GamePage()
		{
			Mouse = new Mouse();
			this.InitializeComponent();
		}

		private void GameBoard_PointerMoved(object sender, PointerRoutedEventArgs e)
		{
			Mouse.SetPosition(e.GetCurrentPoint((UIElement)sender).Position);
		}

		private void GameBoard_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			temp++;
			Mouse.Press();
		}

		private void GameBoard_PointerReleased(object sender, PointerRoutedEventArgs e)
		{
			Mouse.Release();
		}

		private void GameBoard_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
		{
			args.DrawingSession.Clear(Colors.White);
			args.DrawingSession.DrawLine(0, 0, 1000, 1000, Colors.Red);
			if (!Mouse.Dragging)
				args.DrawingSession.DrawCircle(Mouse.GetPosition, 20, Colors.Red);
			else
			{
				args.DrawingSession.FillCircle(Mouse.GetPosition, 20, Colors.Red);
				args.DrawingSession.DrawLine(Mouse.Drager.StartPositionVector, Mouse.GetPosition, Colors.Red);
				args.DrawingSession.DrawText(Mouse.Drager.StartPositionVector.X + " " + Mouse.Drager.StartPositionVector.Y + " " + Mouse.Drager.CurentPositionVector.X + " " + Mouse.Drager.CurentPositionVector.Y + " " + temp, 0, 0, Colors.Black);
			}
			args.DrawingSession.DrawText(Mouse.Position.X + " " + Mouse.Position.Y + " " + temp, 0, 20, Colors.Black);
		}
	}
}
