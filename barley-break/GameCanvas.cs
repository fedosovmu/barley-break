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
		int size;

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
			this.size = this.game.size;

			formColor = Color.FromArgb(250, 248, 239);
			gridColor = Color.FromArgb(187, 173, 160);
			itemColor = Color.FromArgb(238, 228, 218);
			emptyColor = Color.FromArgb(205, 192, 180);
			fontColor = Color.FromArgb(119, 119, 101);

			Bitmap b = new Bitmap(100, 100);
			Graphics gg = Graphics.FromImage(b);	
		}



		public void Click(int x, int y)
		{
			String st = String.Format("X: {0}    Y: {1}", x, y);
			Font font = new Font("Arial", 16);
			SolidBrush brush = new SolidBrush(fontColor);
			int len = lenght / size;
			int X = (x - posX) / len;
			int Y = (y - posY) / len;
			st += String.Format("    [{0}][{1}] ", X, Y);

			if ((X >= 0 && X < size) && (Y >= 0 && Y < size) && (x - posX) > 0 && (y - posY) > 0)
			{

				game.Shift(game[X, Y]);
				DrawGrid();
				g.DrawString("[" + X + "] [" + Y + "]", font, brush, 0, 0);
			}
			else
			{
				DrawGrid();
				g.DrawString("Nope", font, brush, 0, 0);
			}
		}



		public void DrawGrid()
		{
			g.FillRectangle(new SolidBrush(formColor),
				            0, 0, Form1.ActiveForm.Size.Width, Form1.ActiveForm.Size.Height);

			int len = lenght / size;
			int ind = len / 19;

			DrawRoundRec(gridColor, posX, posY, lenght + ind, lenght + ind, 10);

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					int x = posX + i * len + ind;
					int y = posY + j * len + ind;
					int value = game[i, j];
					if (value != 0)
					{
						DrawRoundRec(itemColor, x, y, len - ind, len - ind);

						int fontSize = len / 2;
						String st = Convert.ToString(value);
						Font font = new Font("Arial", fontSize);
						SolidBrush brush = new SolidBrush(fontColor);
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
