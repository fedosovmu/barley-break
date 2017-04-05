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
		static public readonly Color formColor;
		static public readonly Color gridColor;
		static public readonly Color itemColor;
		static public readonly Color emptyColor;
		static public readonly Color fontColor;
		static public readonly Color yelowItemColor;
		static public readonly Color downItemColor;
		static public readonly Color downYellowColor;

		public readonly int posX = 30;
		public readonly int posY = 30;
		int lenght = 420;
		int len;
		int ind;

		bool isSuccess = false;

		Graphics g;
		Game3 game;

		public readonly GameSizePlusMinus gameSizePlusMinus;
		public readonly GameHistoryPanel gameHistoryPanel;

		public readonly GameButton openGameButton;
		public readonly GameButton saveGameButton;
		public readonly GameButton newGameButton;



		static GameCanvas()
		{
			formColor = Color.FromArgb(250, 248, 239);
			gridColor = Color.FromArgb(187, 173, 160);
			itemColor = Color.FromArgb(238, 228, 218);
			yelowItemColor = Color.FromArgb(237, 224, 200);
			emptyColor = Color.FromArgb(205, 192, 180);
			fontColor = Color.FromArgb(119, 119, 101);

			downItemColor = Color.FromArgb(236, 235, 234);
			downYellowColor = Color.FromArgb(249, 234, 194);
		}




		public GameCanvas(Graphics g, Game3 game)
		{
			this.g = g;

			SolidBrush formBrush = new SolidBrush(formColor);
			g.FillRectangle(formBrush, 0, 0, Form1.ActiveForm.Size.Width, Form1.ActiveForm.Size.Height);

			gameSizePlusMinus = new GameSizePlusMinus(g, 240, 500, game.Size);
			gameHistoryPanel = new GameHistoryPanel(g, game, 470, 30);

			newGameButton = new GameButton(g, 360, 500, "New", 95);
			openGameButton = new GameButton(g, 30, 500, "Load");
			saveGameButton = new GameButton(g, 130, 500, "Save");

			OpenGame(game);
		}



		public void OpenGame(Game3 game)
		{
			this.game = game;
			gameHistoryPanel.OpenGame(game);

			len = lenght / game.Size;
			ind = len / 19;

			DrawRoundRec(g, formColor, posX, posY, 440, 440, 10);
			DrawGrid();

			if (game.isSuccess)
				StartWinAnimation();
			else
				isSuccess = false;
		}



        public Game3 Game
        {
            get { return this.game; }
        }



		public void Move(int x, int y)
		{
			gameSizePlusMinus.Move(x, y);
			gameHistoryPanel.Move(x, y);
			newGameButton.Move(x, y);
			openGameButton.Move(x, y);
			saveGameButton.Move(x, y);

			if (isSuccess == false)
			{
				DrawGrid();

				int X = (x - posX) / len;
				int Y = (y - posY) / len;

				if ((X >= 0 && X < game.Size) && (Y >= 0 && Y < game.Size) && (x - posX) > 0 && (y - posY) > 0)
				{
					if (game[X, Y] == 0)
					{
						DrawItem(X, Y, emptyColor, false);
					}
					else if (game[X, Y] == X + Y * game.Size + 1)
					{
						DrawItem(X, Y, downYellowColor);
					}
					else
					{
						DrawItem(X, Y, downItemColor);
					}
				}
			}
		}



		public void Click(int x, int y)
		{
			int X = (x - posX) / len;
			int Y = (y - posY) / len;

			if ((X >= 0 && X < game.Size) && (Y >= 0 && Y < game.Size) && (x - posX) > 0 && (y - posY) > 0)
			{
				if (isSuccess == false)
				{
				game.Shift(game[X, Y]);
				DrawGrid();
				gameHistoryPanel.ShowHistory();
				if (game.isSuccess)
					StartWinAnimation();
				}
			}

			gameHistoryPanel.Click(x, y);
			this.isSuccess = game.isSuccess;
			gameSizePlusMinus.Click(x, y);
			if (newGameButton.IsMouseHover(x, y))			
				this.NewGame();
		}



		private void NewGame()
		{
			int size = gameSizePlusMinus.Value;
			int size2 = (int)Math.Pow(size, 2);
			int[] values = new int[size2];
			for (int i = 0; i < size2; i++)
				values[i] = i + 1;
			values[size2 - 1] = 0;
			Game3 game = new Game3(values);

			game.ReMix();

			OpenGame(game);
		}



		private void StartWinAnimation()
		{
			this.isSuccess = true;

			Color winColor = Color.FromArgb(200, Color.Black);

			//g.FillRectangle(new SolidBrush(winColor), posX, posY, len * game.Size + ind, len * game.Size + ind);
			DrawRoundRec(g, winColor, posX, posY, len * game.Size + ind, len * game.Size + ind, 10);

			Font font = new Font("Consolas", 50, FontStyle.Bold);
			SolidBrush fontBrush = new SolidBrush(Color.White);

			g.DrawString("YOU WIN", font, fontBrush, posX + 75, posY + 170);
		}



		public void DrawGrid()
		{
			DrawRoundRec(g, gridColor, posX, posY, len * game.Size + ind, len * game.Size + ind, 10);

			for (int i = 0; i < game.Size; i++)
				for (int j = 0; j < game.Size; j++)
				{
					int value = game[i, j];

					if (value == 0)
						DrawItem(i, j, emptyColor, false);
					else if (value == i + j * game.Size + 1)
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
			int fontSize = len / 2 - 2;
			Font font = new Font("Arial", fontSize);
			SolidBrush fontBrush = new SolidBrush(fontColor);

			int X = posX + x * len + ind;
			int Y = posY + y * len + ind;
			int value = game[x, y];
			String st = value.ToString();

            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.FitBlackBox
            };
            var rec = new Rectangle(X, Y, len - ind, len - ind);


            DrawRoundRec(g, color, X, Y, len - ind, len - ind);

			if (showValue)
            {
				g.DrawString(st, font, fontBrush, rec, format);	
            }
		}	



		public static void DrawRoundRec(Graphics g, Color color ,int x, int y, int width, int height, int round = 0)
		{
			SolidBrush brush = new SolidBrush(color);
			if (round == 0)
				round = height / 5;

			g.FillPie(brush, new Rectangle(x, y, round + 1, round + 1), 180, 90);
			g.FillPie(brush, new Rectangle(x + width - round - 1, y, round + 1, round + 1), 270, 90);
			g.FillPie(brush, new Rectangle(x + width - round - 1, y + height - round - 1, round + 1, round + 1), 0, 90);
			g.FillPie(brush, new Rectangle(x, y + height - round - 1, round + 1, round + 1), 90, 90);

			int hround = (round + 1) / 2;

			g.FillRectangle(brush, x, y + hround, hround + 1, height - round);
			g.FillRectangle(brush, x + width - hround - 1, y + hround, hround + 1, height - round);
			g.FillRectangle(brush, x + hround, y, width - round, height);
		}
	}
}
