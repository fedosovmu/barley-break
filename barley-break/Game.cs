using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game
	{
		int[] values;
		int[] positions;
		public readonly int size;



		public Game(params int[] values)
		{
			this.values = values;
			double size = Math.Sqrt(values.Length);
			if (size == (int)size)
				this.size = (int)size;		
			else
				throw new ArgumentException("Неверное количество элементов при создании Game");

			positions = new int[values.Length];

			for (int i = 0; i < Math.Pow(size, 2); i++)
				positions[i] = -1;

			for (int i = 0; i < Math.Pow(size, 2); i++)
			{
				int val = values[i];
				if ( val >= 0 && val < Math.Pow(size, 2) && positions[val] == -1)
					positions[val] = i;
				else
					throw new ArgumentException("Неверная инициализация Game");
			}
				
		}



		public int this[int x, int y]
		{
			get { return values[x + size * y]; }
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

			if ((zX == x && (zY + 1 == y || zY - 1 == y))
			|| (zY == y && (zX + 1 == x || zX - 1 == x)))
				Swap(value);
		}



		private void Swap(int val)
		{
			int pos0 = positions[0];
			int pos1 = positions[val];

			values[pos0] = val;
			values[pos1] = 0;

			positions[val] = pos0;
			positions[0] = pos1;
		}
	}
}
