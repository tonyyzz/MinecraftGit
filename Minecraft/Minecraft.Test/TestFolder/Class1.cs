using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServiceStackRedisTest.t
{
	public class Class1
	{
		public static void Do()
		{
			string a = "";
			var g = a ?? throw new Exception("dfgfgd"); //不可，只能判断是否为null，不能判断是否为空字符串
		}
	}
}
