using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game
	{
		protected int[] values;
		protected int[] positions;
		public readonly int Size;



		public Game(params int[] values)
		{
			this.values = values;
			this.Size = (int) Math.Sqrt(values.Length);

			positions = new int[values.Length];

			for (int i = 0; i < Math.Pow(Size, 2); i++)
				positions[i] = -1;

			for (int i = 0; i < Math.Pow(Size, 2); i++)
			{
				int val = values[i];
				if (val >= 0 && val < Math.Pow(Size, 2) && positions[val] == -1)
					positions[val] = i;
				else
					throw new ArgumentException("Неверная инициализация Game");
			}
		}



		public int this[int x, int y]
		{
			get { return values[x + Size * y]; }
			set
			{
				if (value < 0 || value > Math.Pow(Size, 2))
					throw new ArgumentException("Ошибка при изменении значения в Game");
				values[x + Size * y] = value;
				positions[value] = x + Size * y;
			}
		}



		public Tuple<int, int> GetLocation(int value)
		{
			int x = positions[value] % Size;
			int y = positions[value] / Size;
			return new Tuple<int, int> (x, y);
		}



		public virtual bool Shift(int value)
		{
			if (value < 0 || value >= Math.Pow(Size, 2))
				throw new ArgumentException("Невозможно передвинуть элемент которого нет в game");

			int pos = positions[value];
			int x = pos % Size;
			int y = pos / Size;

			int posZ = positions[0];
			int X = posZ % Size;
			int Y = posZ / Size;

			bool isNear = (Math.Abs(X - x) == 1 && Y == y) || (X == x && (Math.Abs(Y - y) == 1));
			if (isNear)
				Swap(value);

			return isNear;
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
