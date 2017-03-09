using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace barley_break
{
	static class csvHandler
	{
		public static Game3 Load(String path)
		{
			String text = System.IO.File.ReadAllText(path);

			String[] cells = Regex.Split(text, "[,\n]");

			int[] values = new int[cells.Length];

			for (int i = 0; i < values.Length; i++)
				values[i] = Convert.ToInt32( cells[i] );
	
			return new Game3(values);
		}



		public static void Save(Game3 game, String path)
		{
            String[] lines = new String[game.size];

            for (int i = 0; i < game.size; i++)
            {
                int[] values = new int[game.size];
                for (int j = 0; j < game.size; j++)
                    values[j] = game[j, i];

                lines[i] = String.Join(",", values);
            }

            String text = String.Join("\n", lines);
            System.IO.File.WriteAllText(path, text);
		}
	}
}
