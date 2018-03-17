using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test.TestFolder
{
	public class JsonFileTest
	{
		public static void Do()
		{
			var jsonConfigVal = JsonConfig.Value;
			Console.WriteLine(jsonConfigVal.JsonSerialize());
		}
	}


}
