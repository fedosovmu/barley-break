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
		List<String> history;

		GameButton BackButton;
		GameButton BackFiveButton;



		public GameHistoryPanel(Graphics g, int X, int Y)
		{
			this.X = X;
			this.Y = Y;
			this.g = g;

			GameCanvas.DrawRoundRec(g, GameCanvas.gridColor, X, Y, 200, 520, 20);
			GameCanvas.DrawRoundRec(g, GameCanvas.emptyColor, X + 5, Y + 55, 190, 460, 20);

			BackButton = new GameButton(g, X, Y, "Back");
			BackFiveButton = new GameButton(g, X + 100, Y, "Back 5", 100, 50);
		}



		public void Add(String line)
		{
			//history.Add(line);
			Font font = new Font("Verdana", 14);
			SolidBrush fontBrush = new SolidBrush(Color.White);

			for (int i = 0; i < 15; i++)
			{
				// <----
				//String st = Convert.ToString(i);
				g.DrawString(line, font, fontBrush, X + 20, Y + 65 + i * 30);
			}
		}



		public void Click(int x, int y)
		{
			// <-----
		}



		public void Move(int x, int y)
		{
			BackButton.Move(x, y);
			BackFiveButton.Move(x, y);
		}

	}
}
