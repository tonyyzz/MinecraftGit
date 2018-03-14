using Minecraft.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test.TestFolder
{
	public class DbServerConnCheckTest
	{
		public static void Do()
		{
			StartBLL.StartDBServerCheck();
			Console.WriteLine("连接成功");
		}
	}
}
