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

			GameCanvas.DrawRoundRec(g, GameCanvas.gridColor, X, Y, 200, 520, 20);

			BackButton = new GameButton(g, X, Y, "Back");
			BackFiveButton = new GameButton(g, X + 100, Y, "Back 5", 100, 50);

			OpenGame(game);
		}



		public void OpenGame(Game3 game)
		{
			this.game = game;
			ShowHistory();
		}



		public void ShowHistory()
		{
			GameCanvas.DrawRoundRec(g, GameCanvas.emptyColor, X + 5, Y + 55, 190, 460, 20);

			Font font = new Font("Verdana", 14);
			SolidBrush fontBrush = new SolidBrush(GameCanvas.formColor);

			int start = 0;
			if (game.history.Count > 15)
				start = game.history.Count - 15;

			for (int i = start; i < game.history.Count; i++)
			{
				String st = Convert.ToString(game.history.ElementAt(i)); 
				g.DrawString(st, font, fontBrush, X + 20, Y + 65 + (i - start) * 30);
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
