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
		List<String> history;

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
			GameCanvas.DrawRoundRec(g, GameCanvas.emptyColor, X + 5, Y + 55, 190, 460, 20);
			history = new List<String>();
		}



		public void Add(String line)
		{
			history.Add(line);

			GameCanvas.DrawRoundRec(g, GameCanvas.emptyColor, X + 5, Y + 55, 190, 460, 20);

			Font font = new Font("Verdana", 14);
			SolidBrush fontBrush = new SolidBrush(GameCanvas.formColor);

			int start = 0;
			if (history.Count > 15)
				start = history.Count - 15;

			for (int i = start; i < history.Count; i++)
			{
				String st = history[i]; 
				g.DrawString(st, font, fontBrush, X + 20, Y + 65 + (i - start) * 30);
			}
		}



		public void Click(int x, int y)
		{
			// <-----
			if (BackButton.IsMouseHover(x, y))
			{
				if (history.Count >= 1)
				history.RemoveAt(history.Count - 1);
			}
			else if (BackFiveButton.IsMouseHover(x,y))
			{
				if (history.Count >= 5)
				for (int i = 0; i < 5; i ++)
					history.RemoveAt(history.Count - 1);
			}
		}



		public void Move(int x, int y)
		{
			BackButton.Move(x, y);
			BackFiveButton.Move(x, y);
		}

	}
}
