using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game
	{
		int[] array;
		int[] positions;
		public readonly int size;



		public Game(params int[] array)
		{
			this.array = array;
			double size = Math.Sqrt(array.Length);
			if (size == (int)size)
				this.size = (int)size;		
			else
				throw new ArgumentException("Неверное количество элементов при создании Game");

			Array.Resize<int>(ref positions, array.Length);

			for (int i = 0; i < Math.Pow(size, 2); i++)
				positions[i] = -1;

			for (int i = 0; i < Math.Pow(size, 2); i++)
			{
				int val = array[i];
				if ( val >= 0 && val < Math.Pow(size, 2) && positions[val] == -1)
					positions[val] = i;
				else
					throw new ArgumentException("Неверная инициализация Game");
			}
				
		}



		public int this[int x, int y]
		{
			get { return array[x + size * y]; }
		}



		public Tuple<int, int> GetLocation(int value)
		{
			int x = positions[value] % size;
			int y = positions[value] / size;
			return new Tuple<int, int> (x, y);
		}



		public void Shift(int value)
		{
			if (value < 0 || value >= Math.Pow(size, 2))
				throw new ArgumentException("Невозможно передвинуть элемент которого нет в game");

			int pos = positions[value];
			int x = pos % size;
			int y = pos / size;

			int posZ = positions[0];
			int zX = posZ % size;
			int zY = posZ / size;

			if (!(zX == x && zY == y))
				if ((zX == x && (zY + 1 == y || zY - 1 == y))
				|| (zY == y && (zX + 1 == x || zX - 1 == x)))
					Swap(value);
				else
					Form1.ActiveForm.Text = "I can't shift " + Convert.ToString(value);
			else
				Form1.ActiveForm.Text = "It is 0";
		}



		private void Swap(int val)
		{
			Form1.ActiveForm.Text = "Shift: " + val.ToString();

			int pos0 = positions[0];
			int pos1 = positions[val];

			array[pos0] = val;
			array[pos1] = 0;

			positions[val] = pos0;
			positions[0] = pos1;
		}
	}
}
