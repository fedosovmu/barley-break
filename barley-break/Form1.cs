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

			Graphics g = this.CreateGraphics();
			gameCanvas = new GameCanvas(g, game);
		}



		private void Form1_Click(object sender, EventArgs e)
		{
			int x = Cursor.Position.X;
			int y = Cursor.Position.Y;
			Point p = PointToClient( new Point(x, y) );
			gameCanvas.Click(p.X, p.Y);
		}



		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			// <- Ё-хо-хо здесь будет подсветка кнопок, когда я сделаю нормальную отрисовку без мерцания
		}
	}
}
