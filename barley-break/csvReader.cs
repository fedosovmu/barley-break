using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace barley_break
{
	static class csvReader
	{
		public static int[] Load(String path)
		{
			String text = System.IO.File.ReadAllText(path);

			String[] cells = Regex.Split(text, "[,{\n}]");

			int[] values = new int[cells.Length];

			for (int i = 0; i < values.Length; i++)
				values[i] = Convert.ToInt32( cells[i] );
	
			return values;
		}
	}
}
