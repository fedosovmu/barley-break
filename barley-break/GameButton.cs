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
		static public readonly Color buttonColor;
		static public readonly Color textColor;
		static public readonly Color downButtonColor;

		public readonly int X;
		public readonly int Y;
		public readonly String Text;
		public readonly int Width;
		public readonly int Height;
		int indW;
		int indH;

		bool isMouseHover = false;

		Graphics g;



		static GameButton()
		{
			buttonColor = Color.FromArgb(133, 109, 85);
			textColor = Color.FromArgb(250, 248, 239);
			downButtonColor = Color.FromArgb(95, 73, 49);
		}



		public GameButton(Graphics g ,int X, int Y, String Text, int Width = 90, int Height = 50, int indW = 0)
		{
			this.Width = Width;
			this.Height = Height;

			this.g = g;
			this.X = X;
			this.Y = Y;
			this.Text = Text;

			if (indW != 0)
				this.indW = indW;
			else
				this.indW = Width / 6;
			this.indH = Height / 4;

			ReDraw(buttonColor);
		}



		public void Move(int x, int y)
		{
			if (IsMouseHover(x, y))
			{
				if (!isMouseHover)
				{
					isMouseHover = true;
					ReDraw(downButtonColor);
				}
			}
			else
			{
				if (isMouseHover)
				{
					isMouseHover = false;
					ReDraw(buttonColor);
				}
			}
		}



		public bool IsMouseHover(int x, int y)
		{
			return (x >= X && x <= X + Width && y >= Y && y <= Y + Height);
		}



		public void ReDraw()
		{
			ReDraw(buttonColor);
		}



		public void ReDraw(Color color)
		{
			GameCanvas.DrawRoundRec(g, color, X, Y, Width, Height);

			SolidBrush fontBrush = new SolidBrush(textColor);
			Font font = new Font("Arial", 16, FontStyle.Bold);

			g.DrawString(Text, font, fontBrush, X + indW, Y + indH);
		}

	}
}
