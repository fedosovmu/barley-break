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

		Graphics g;
		Game game;

		Color formColor;
		Color gridColor;
		Color itemColor;
		Color emptyColor;
		Color fontColor;



		public GameCanvas(Graphics g, Game game)
		{
			this.g = g;
			this.game = game;

			formColor = Color.FromArgb(250, 248, 239);
			gridColor = Color.FromArgb(187, 173, 160);
			itemColor = Color.FromArgb(238, 228, 218);
			emptyColor = Color.FromArgb(205, 192, 180);
			fontColor = Color.FromArgb(119, 119, 101);

			DrawGrid();
		}



		public void Click(int x, int y)
		{
			Font font = new Font("Arial", 16);
			SolidBrush brush = new SolidBrush(fontColor);

			int len = lenght / game.size;
			int X = (x - posX) / len;
			int Y = (y - posY) / len;

			if ((X >= 0 && X < game.size) && (Y >= 0 && Y < game.size) && (x - posX) > 0 && (y - posY) > 0)
			{

				game.Shift(game[X, Y]);
				DrawGrid();
				g.DrawString("[" + X + "] [" + Y + "]", font, brush, 0, 0);
			}
			else
			{
				DrawGrid();
				g.DrawString("Nope", font, brush, 0, 0);
				Form1.ActiveForm.Text = "Nope";
			}
		}



		public void DrawGrid()
		{
			SolidBrush formBrush = new SolidBrush(formColor);
			g.FillRectangle(formBrush, 0, 0, Form1.ActiveForm.Size.Width, Form1.ActiveForm.Size.Height);

			int len = lenght / game.size;
			int ind = len / 19;

			int fontSize = len / 2;
			Font font = new Font("Arial", fontSize);
			SolidBrush brush = new SolidBrush(fontColor);

			DrawRoundRec(gridColor, posX, posY, lenght + ind, lenght + ind, 10);

			for (int i = 0; i < game.size; i++)
			{
				for (int j = 0; j < game.size; j++)
				{
					int x = posX + i * len + ind;
					int y = posY + j * len + ind;
					int value = game[i, j];
					if (value != 0)
					{
						DrawRoundRec(itemColor, x, y, len - ind, len - ind);

						String st = value.ToString();
						g.DrawString(st, font, brush, x, y);

					}
					else
						DrawRoundRec(emptyColor, x, y, len - ind, len - ind);
				}
			}

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
