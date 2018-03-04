using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Config;
using Minecraft.Model.ReqResp;

namespace Minecraft.ConnTest.Receive
{
	public class Test_TestCmd
	{
		public void Execute(string respStr)
		{
			Console.WriteLine(DateTime.Now.ToStr());
			var resp = respStr.JsonDeserialize<TestResp>();
			if (resp == null)
			{
				return;
			}
		}
	}
}
