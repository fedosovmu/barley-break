using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barley_break
{
	public partial class Form1 : Form
	{
		GameCanvas gameCanvas;
		Bitmap btm;
		GameButton OpenGameButton;
		GameButton saveGameButton;
		GameButton newGameButton;



		public Form1()
		{
			InitializeComponent();
		}

		

		private void Form1_Shown(object sender, EventArgs e)
		{
			int[] a = { 3, 1, 2, 0 };
			int[] b = { 7, 6, 5, 8, 2, 1, 0, 3, 4 };
			int[] c = { 6, 14, 0, 11, 13, 10, 1, 2, 9, 8, 7, 15, 5, 4, 3, 12 };

			Game game = new Game(c);

			btm = new Bitmap(this.Size.Width, this.Size.Height);
			Graphics g = Graphics.FromImage(btm);

			gameCanvas = new GameCanvas(g, game);
			OpenGameButton = new GameButton(g, 30, 500, "Load");
			saveGameButton = new GameButton(g, 130, 500, "Save");
			newGameButton = new GameButton(g, 360, 500, " New");

			this.DoubleBuffered = true;
			this.BackgroundImage = btm;
			this.Refresh();
		}



		private void Form1_Click(object sender, EventArgs e)
		{
			int x = Cursor.Position.X;
			int y = Cursor.Position.Y;
			Point p = PointToClient( new Point(x, y) );

			gameCanvas.Click(p.X, p.Y);

			if (OpenGameButton.Click(p.X, p.Y))
				this.LoadGame();

			if (saveGameButton.Click(p.X, p.Y))
				this.SaveGame();

			if (newGameButton.Click(p.X, p.Y))
				this.NewGame();

			this.Refresh();
		}



		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			int x = Cursor.Position.X;
			int y = Cursor.Position.Y;
			Point p = PointToClient(new Point(x, y));

			gameCanvas.Move(p.X, p.Y);
			OpenGameButton.Move(p.X, p.Y);
			saveGameButton.Move(p.X, p.Y);
			newGameButton.Move(p.X, p.Y);

			this.Refresh();
		}



		private void LoadGame()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.ShowDialog();

			if (dialog.FileName != "")
			{
				Game game = csvHandler.Load(dialog.FileName);
				gameCanvas.OpenGame(game);

			}
				

			OpenGameButton.ReDraw();
		}



		private void SaveGame()
		{
			// < ---
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.ShowDialog();
		}



		private void NewGame()
		{
			// < ---
		}
	}
}
