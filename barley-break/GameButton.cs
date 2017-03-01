using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace barley_break
{
	class GameButton
	{
		public readonly int X;
		public readonly int Y;
		public readonly string Text;
		public readonly int Width = 150;
		public readonly int Height = 50;

		Graphics g;
		Color buttonColor;
		Color textColor;
		Color downButtonColor;


		public GameButton(Graphics g ,int X, int Y, String Text)
		{
			buttonColor = Color.FromArgb(133, 109, 85);
			textColor = Color.FromArgb(250, 248, 239);
			downButtonColor = Color.FromArgb(95, 73, 49);

			this.g = g;
			this.X = X;
			this.Y = Y;
			this.Text = Text;

			ReDraw(buttonColor);
		}



		public bool Click(int x, int y)
		{
			if (IsMouseHover(x, y))
			{
				ReDraw(downButtonColor);
				return true;
			}
			else
			{
				ReDraw(buttonColor);
				return false;
			}
		}



		public void Move(int x, int y)
		{
			if (IsMouseHover(x, y))
				ReDraw(downButtonColor);
			else
				ReDraw(buttonColor);
		}



		private bool IsMouseHover(int x, int y)
		{
			return (x >= X && x <= X + Width && y >= Y && y <= Y + Height);
		}



		public void ReDraw()
		{
			ReDraw(buttonColor);
		}



		private void ReDraw(Color color)
		{
			GameCanvas.DrawRoundRec(g, color, X, Y, Width, Height, 10);

			SolidBrush fontBrush = new SolidBrush(textColor);
			Font font = new Font("Arial", 16);

			g.DrawString(Text, font, fontBrush, X + 15, Y + 15);
		}

	}
}
