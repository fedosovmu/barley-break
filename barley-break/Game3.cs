using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
	class Game3 : Game2
	{
		public readonly Stack<int> History;



		public Game3(params int[] values) : base(values)
		{
			History = new Stack<int>();
		}



        public override bool Shift(int value)
		{
            bool isShifted = base.Shift(value);
            if (isShifted)
				History.Push(value);
            return isShifted;
		}



		public void Back(int count = 1)
		{
			if (History.Count < count)
				count = History.Count;

			for (int i = 0; i < count; i++)
				base.Shift(History.Pop());
		}

	}
}
