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
		int size = 4;

		Graphics g;
		Game game;
		Color gridColor;
		Color itemColor;
		Color emptyColor;
		Color formColor;



		public GameCanvas(Graphics g, Game game)
		{
			this.g = g;
			this.game = game;

			formColor = Color.FromArgb(250, 248, 239);
			gridColor = Color.FromArgb(187, 173, 160);
			itemColor = Color.FromArgb(238, 228, 218);
			emptyColor = Color.FromArgb(205, 192, 180);
		}



		public void DrawGrid()
		{
			g.FillRectangle(new SolidBrush(formColor),
				            0, 0, Form1.ActiveForm.Size.Height, Form1.ActiveForm.Size.Width);

			int len = lenght / size;
			int ind = len / 19;

			DrawRoundRec(gridColor, posX, posY, lenght + ind, lenght + ind, 10);

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					int x = posX + i * len + ind;
					int y = posY + j * len + ind;
					DrawRoundRec(itemColor, x, y, len - ind, len - ind);
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
