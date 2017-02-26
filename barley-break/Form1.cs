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
			Graphics g = this.CreateGraphics();
			gameCanvas = new GameCanvas(g, new Game()); // <- Надо бы придумать что-то по оригинальнее
			gameCanvas.DrawGrid();
		}



		private void Form1_Click(object sender, EventArgs e)
		{
			gameCanvas.DrawGrid();
		}
	}
}
