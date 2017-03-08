using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game2 : Game
	{
		public Game2(params int[] values)
			: base(values) { }



		public void ReMix()
		{
			Random rand = new Random();

			for (int i = 0; i < Math.Pow(size, 2); i++)
			{
				int x = rand.Next(0, size - 1);
				int y = rand.Next(0, size - 1);
				int count = rand.Next(1, 3);

				Rotate(x, y, count);
			}
		}



		private void Rotate(int x, int y, int count = 1)
		{ 
			if (count < 1 || count > 3) // count = [1 .. 3] 
				throw new ArgumentException("Неверное количество поворотов при перемешивании Game2");

			for (int i = 1; i <= count; i++)
			{
				int val = this[x, y];

				this[x, y] = this[x + 1, y];
				this[x + 1, y] = this[x + 1, y + 1];
				this[x + 1, y + 1] = this[x, y + 1];
				this[x, y + 1] = val;
			}
		}



		public bool isSuccess
		{
			get
			{
				for (int i = 0; i < size; i++)		
					for (int j = 0; j < size; j++)
						if (this[i, j] != (i + j * size + 1) % (size * size))
							return false;
				return true;
			}
		}

	}
}
