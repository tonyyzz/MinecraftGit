using Minecraft.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.InitTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--------------【Minecraft初始化】---------------");

			StartBLL.StartDBServerCheck();

			//执行初始化方法
			Init.Do();

			Console.WriteLine();

			Console.WriteLine("按任意键退出程序");
			Console.ReadKey();

		}
	}
}
