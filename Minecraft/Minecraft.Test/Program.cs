using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Config.ipConst;
using Minecraft.Model.ReqResp;
using Minecraft.ServiceStackRedisTest.t;
using Minecraft.Test.TestFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			////获取执行文件的文件路径
			//var execName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);

			//var type = typeof(BaseResp);
			//var platwr = new TestReq().PlayerId;
			//var gg = new TestReq();
			//var name = nameof(platwr);
			// name = nameof(gg.PlayerId);

			//var d = CommonConfig.GetTablePostfix(10000, 10000);

			//var dict= IpConstConfig.GetConstConfigDict();
			Console.WriteLine("测试");
			JsonFileTest.Do();
			Console.ReadKey();
		}

	}
}
