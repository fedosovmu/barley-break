using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game3 : Game2
	{
		List<int> history;



		public Game3(params int[] values) : base(values)
		{
			history = new List<int>();
		}



		public new void Shift (int value)
		{
			history.Add(value);
			base.Shift(value);
		}



		public void Back(int count = 1)
		{

		}

	}
}
