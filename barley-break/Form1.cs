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
		public Form1()
		{
			InitializeComponent();
		}



		private void Form1_Click(object sender, EventArgs e)
		{
			// <- Клик на форму
			//Graphics g = this.CreateGraphics();

			//Pen myPen = new Pen(Color.Black, 1);
			//g.DrawLine(myPen, 10, 10, 100, 100);
		}



		private void Form1_Shown(object sender, EventArgs e)
		{
			Graphics g = this.CreateGraphics();

			Pen myPen = new Pen(Color.Black, 1);
			g.DrawRectangle(myPen, 20, 20, 360, 360); // размер экрана 360 на 360
			for (int i = 1; i <= 3; i++)
			{
				int pos = 20 + 90 * i;
				g.DrawLine(myPen, 20, pos, 380, pos);
				g.DrawLine(myPen, pos, 20, pos, 380);
			}

		}
	}
}
