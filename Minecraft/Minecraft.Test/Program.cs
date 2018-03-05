using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
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
			//获取执行文件的文件路径
			var execName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);

			var type = typeof(MsgResp);
			var name = nameof(MsgResp);
		}
		
	}
}
