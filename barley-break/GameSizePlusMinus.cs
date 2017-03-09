using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace barley_break
{
	class GameSizePlusMinus
	{
		public int Value;
		public readonly int X;
		public readonly int Y;
		Graphics g;
		GameButton plusButton;
		GameButton minusButton;



		public GameSizePlusMinus(Graphics g ,int X, int Y, int Value)
		{
			this.g = g;
			this.X = X;
			this.Y = Y;
			this.Value = Value;

			SolidBrush brush = new SolidBrush(GameCanvas.gridColor);
			g.FillRectangle(brush, X + 25, Y, 55, 50);

			DrawValue();

			minusButton = new GameButton(g, X, Y, "~", 30, 50);
			plusButton = new GameButton(g, X + 75, Y, "+", 30, 50);
		}



		public void Click(int x, int y)
		{
			int minValue = 2;
			int maxValue = 9;

			if (minusButton.IsMouseHover(x, y) && Value > minValue)
			{
				Value -= 1;
				DrawValue();

			}
			else if (plusButton.IsMouseHover(x, y) && Value < maxValue)
			{
				Value += 1;
				DrawValue();
			}
		}



		public void Move(int x, int y)
		{
			minusButton.Move(x, y);
			plusButton.Move(x, y);
		}



		private void DrawValue()
		{
			SolidBrush brush = new SolidBrush(GameCanvas.gridColor);
			g.FillRectangle(brush, X + 30, Y, 40, 50);

			Font font = new Font("Arial", 26, FontStyle.Bold);
			SolidBrush fontBrush = new SolidBrush(Color.White);

			String st = Convert.ToString(Value);
			g.DrawString(st, font, fontBrush, X + 36, Y + 5);
		}
	}
}
