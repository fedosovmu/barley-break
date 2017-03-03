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
		int Value;
		public readonly int X;
		public readonly int Y;
		Graphics g;
		GameButton plusButton;
		GameButton minusButton;
		GameButton newGameButton;



		public GameSizePlusMinus(Graphics g ,int X, int Y, int Value)
		{
			this.g = g;
			this.X = X;
			this.Y = Y;
			this.Value = Value;

			DrawValue();

			minusButton = new GameButton(g, X, Y, "~", 30, 50);
			plusButton = new GameButton(g, X + 75, Y, "+", 30, 50);
			newGameButton = new GameButton(g, X + 120 , Y, " New", 95);
		}



		public void Click(int x, int y)
		{

			if (minusButton.IsMouseHover(x, y))
			{
				Value -= 1;
				DrawValue();
				minusButton.ReDraw(GameButton.downButtonColor);
				plusButton.ReDraw(GameButton.buttonColor);
			}
			else if (plusButton.IsMouseHover(x, y))
			{
				Value += 1;
				DrawValue();
				minusButton.ReDraw(GameButton.buttonColor);
				plusButton.ReDraw(GameButton.downButtonColor);
			}
		}



		public void Move(int x, int y)
		{
			minusButton.Move(x, y);
			plusButton.Move(x, y);
			newGameButton.Move(x, y);
		}



		private void DrawValue()
		{
			SolidBrush brush = new SolidBrush(GameCanvas.gridColor);
			g.FillRectangle(brush, X + 20, Y, 80, 50);

			Font font = new Font("Arial", 26, FontStyle.Bold);
			SolidBrush fontBrush = new SolidBrush(Color.White);

			String st = Convert.ToString(Value);
			g.DrawString(st, font, fontBrush, X + 36, Y + 5);
		}
	}
}
