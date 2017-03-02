using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game2 : Game
	{
		void ReMix()
		{
			if (size == 1)
				return;

			for (int i = 0; i < Math.Pow(size, 2); i++)
				return;
		}



		private void Rotate(int x, int y, int count = 1)
		{ 
			if (count < 1 || count > 3) // count = [1 .. 3] 
				throw new ArgumentException("Неверное количество поворотов при перемешивании Game2");

			// x + size * y
			//
			//
			// [x, y]         - >  [x + 1, y]
			// [x + 1, y]     - >  [x + 1, y + 1]
			// [x + 1, y + 1] - >  [x, y + 1]
			// [x, y + 1]     - >  [x, y]
			//
			//
			// [x, y]         -  x + size * y
			// [x + 1, y]     -  x + 1 + size * y
			// [x + 1, y + 1] -  x + 1 + size * (y + 1)
			// [x, y + 1]     -  x + size * (y + 1)
			//
			//
			for (int i = 0; i < count; i++)
			{
				int tempVal;
			}

		}



		bool isSuccess
		{
			get
			{
				for (int i = 0; i < size; i++)		
					for (int j = 0; j < size; j++)
						if (this[i, j] != i + j * size + 1)
							return false;
				return true;
			}
		}

	}
}
