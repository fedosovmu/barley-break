using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace barley_break
{
	class GameCanvas
	{
		int posX = 30;
		int posY = 30;
		int lenght = 420;
		int len;
		int ind;

		Graphics g;
		Game game;

		Color formColor;
		Color gridColor;
		Color itemColor;
		Color emptyColor;
		Color fontColor;
		Color yelowItemColor;
		Color downItemColor;
		Color downYellowColor;



		public GameCanvas(Graphics g, Game game)
		{
			this.g = g;
			this.game = game;

			formColor = Color.FromArgb(250, 248, 239);
			gridColor = Color.FromArgb(187, 173, 160);
			itemColor = Color.FromArgb(238, 228, 218);
			yelowItemColor = Color.FromArgb(237, 224, 200);
			emptyColor = Color.FromArgb(205, 192, 180);
			fontColor = Color.FromArgb(119, 119, 101);

			downItemColor = Color.FromArgb(236, 235, 234);
			downYellowColor = Color.FromArgb(249, 234, 194);

			len = lenght / game.size;
			ind = len / 19;

			DrawGrid();
		}



		public void Move(int x, int y)
		{
			int X = (x - posX) / len;
			int Y = (y - posY) / len;

			if ((X >= 0 && X < game.size) && (Y >= 0 && Y < game.size) && (x - posX) > 0 && (y - posY) > 0)
			{
				if (game[X, Y] == 0)
					DrawItem(X, Y, emptyColor, false);
				else if (game[X, Y] == X + Y * game.size + 1)
					DrawItem(X, Y, downYellowColor);
				else
					DrawItem(X, Y, downItemColor);
			}
		}



		public void Click(int x, int y)
		{
			int X = (x - posX) / len;
			int Y = (y - posY) / len;

			if ((X >= 0 && X < game.size) && (Y >= 0 && Y < game.size) && (x - posX) > 0 && (y - posY) > 0)
			{
				game.Shift(game[X, Y]);
				DrawGrid();
			}
			else
			{
				DrawGrid();
			}
		}



		public void DrawGrid()
		{
			SolidBrush formBrush = new SolidBrush(formColor);
			g.FillRectangle(formBrush, 0, 0, Form1.ActiveForm.Size.Width, Form1.ActiveForm.Size.Height);

			DrawRoundRec(gridColor, posX, posY, lenght + ind, lenght + ind, 10);

			for (int i = 0; i < game.size; i++)
				for (int j = 0; j < game.size; j++)
				{
					int value = game[i, j];

					if (value == 0)
						DrawItem(i, j, emptyColor, false);
					else if (value == i + j * game.size + 1)
					{
						DrawItem(i, j, yelowItemColor);
					}
					else
					{
						DrawItem(i, j, itemColor);
					}
				}
		}



		private void DrawItem(int x, int y, Color color, bool showValue = true)
		{
			int fontSize = len / 2;
			Font font = new Font("Arial", fontSize);
			SolidBrush fontBrush = new SolidBrush(fontColor);

			int X = posX + x * len + ind;
			int Y = posY + y * len + ind;
			int value = game[x, y];
			String st = value.ToString();

			DrawRoundRec(color, X, Y, len - ind, len - ind);
			if (showValue)
				g.DrawString(st, font, fontBrush, X, Y);								
		}	



		private void DrawRoundRec(Color color ,int x, int y, int width, int height, int round = 0)
		{
			SolidBrush brush = new SolidBrush(color);
			if (round == 0)
				round = width / 5;

			g.FillEllipse(brush, x, y, round, round);
			g.FillEllipse(brush, x + width - round, y, round, round);
			g.FillEllipse(brush, x, y + height - round, round, round);
			g.FillEllipse(brush, x + width - round, y + height - round, round, round);
			int hround = round / 2;
			g.FillRectangle(brush, x, y + hround, width, height - round);
			g.FillRectangle(brush, x + hround, y, width - round, height);
		}
	}
}
