using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game3 : Game2
	{
		public readonly Stack<int> history;



		public Game3(params int[] values) : base(values)
		{
			history = new Stack<int>();
		}



		public new void Shift (int value)
		{
			if (base.Shift(value))
				history.Push(value);
		}



		public void Back(int count = 1)
		{
			if (history.Count < count)
				count = history.Count;

			for (int i = 0; i < count; i++)
				base.Shift(history.Pop());
		}

	}
}
