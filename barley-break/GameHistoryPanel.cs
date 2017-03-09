using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace barley_break
{
	class GameHistoryPanel
	{
		public readonly int X;
		public readonly int Y;
		Graphics g;
		Game3 game;

		GameButton BackButton;
		GameButton BackFiveButton;



		public GameHistoryPanel(Graphics g, Game3 game, int X, int Y)
		{
			this.X = X;
			this.Y = Y;
			this.g = g;

			GameCanvas.DrawRoundRec(g, GameCanvas.gridColor, X, Y, 100, 520, 20);

			BackButton = new GameButton(g, X + 5, Y + 5, "Back");
			BackFiveButton = new GameButton(g, X + 5, Y + 60, "Back 5", 90, 50, 7);

			OpenGame(game);
		}



		public void OpenGame(Game3 game)
		{
			this.game = game;
			ShowHistory();
		}



		public void ShowHistory()
		{
			GameCanvas.DrawRoundRec(g, GameCanvas.emptyColor, X + 5, Y + 115, 90, 400, 20);

			Font font = new Font("Verdana", 14);
			SolidBrush fontBrush = new SolidBrush(GameCanvas.formColor);

			int size = 13;
			if (game.history.Count < 13)
				size = game.history.Count;

			for (int i = 0; i < size; i++)
			{
				String st = Convert.ToString(game.history.ElementAt(i));
				st += " -> 0";
				g.DrawString(st, font, fontBrush, X + 15, Y + 120 + i * 30);
			}
		}



		public void Click(int x, int y)
		{
			if (BackButton.IsMouseHover(x, y))
			{
				game.Back();
				ShowHistory();
			}
			else if (BackFiveButton.IsMouseHover(x,y))
			{
				game.Back(5);
				ShowHistory();
			}
		}



		public void Move(int x, int y)
		{
			BackButton.Move(x, y);
			BackFiveButton.Move(x, y);
		}

	}
}
