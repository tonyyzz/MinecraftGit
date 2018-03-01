using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConsoleCloseTest
{
	class Program
	{
		delegate bool ConsoleCtrlDelegate(int dwCtrlType);
		const int CTRL_CLOSE_EVENT = 2;
		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);

		static void Main(string[] args)
		{
			ConsoleCtrlDelegate newDelegate = new ConsoleCtrlDelegate(HandlerRoutine);
			if (SetConsoleCtrlHandler(newDelegate, true))
			{
				#region 任务代码区
				//这里执行你自己的任务，我举例输出几个数字，为了展示长时间的任务，我用了Sleep
				Console.WriteLine("1");
				System.Threading.Thread.Sleep(5000);
				Console.WriteLine("2");
				System.Threading.Thread.Sleep(2000);
				Console.WriteLine("Over, 2秒后退出");  //yzz
				System.Threading.Thread.Sleep(2000);
				#endregion
			}
			else
			{
				Console.WriteLine("抱歉，API注入失败，按任意键退出！");
				Console.ReadKey();
			}

		}

		static bool HandlerRoutine(int CtrlType)
		{
			switch (CtrlType)
			{
				case CTRL_CLOSE_EVENT:       //用户要关闭Console了
					Console.WriteLine();
					Console.WriteLine("任务还没有完成，确认要退出吗？（Y/N）");
					ConsoleKeyInfo ki = Console.ReadKey();
					return ki.Key == ConsoleKey.Y;
				default:
					return true;
			}
		}
	}
}
