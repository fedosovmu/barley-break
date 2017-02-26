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
		const int LENGHT = 380;
		Graphics g;
		Game game;
		SolidBrush foundBrush;
		SolidBrush itemBrush;
		SolidBrush formColor;


		public GameCanvas(Graphics g, Game game)
		{
			this.g = g;
			this.game = game;

			foundBrush = new SolidBrush(Color.FromArgb(181, 164, 148));
			itemBrush = new SolidBrush(Color.FromArgb(205, 192, 180));
			formColor = new SolidBrush(Color.FromArgb(251, 249, 237));
		}



		public void DrawGrid()
		{
			//DrawRoundRec(foundBrush, 20, 20, LENGHT, LENGHT);
			g.FillRectangle(formColor, 0, 0, Form1.ActiveForm.Size.Height, Form1.ActiveForm.Size.Width);

			int posX = 10;
			int posY = 10;
			int lenght = 100;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int x = posX + i * (lenght + 20);
					int y = posY + j * (lenght + 20);
					DrawRoundRec(itemBrush, x, y, lenght, lenght);
				}
			}
		}



		private void DrawRoundRec(SolidBrush brush ,int x, int y, int width, int height)
		{
			int round = 10;

			g.FillEllipse(brush, x, y, round, round);
			g.FillEllipse(brush, x + width, y, round, round);
			g.FillEllipse(brush, x, y + height, round, round);
			g.FillEllipse(brush, x + width, y + height, round, round);
			int hround = round / 2;
			g.FillRectangle(brush, x + hround, y, width, height + round);
			g.FillRectangle(brush, x, y + hround, width + round, height);
		}
	}
}
