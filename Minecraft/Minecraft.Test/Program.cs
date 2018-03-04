using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp.Player;
using System;
using System.Collections.Generic;
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
			var str = new MsgResp(MsgLevelEnum.Info, "信息").JsonSerialize();
		}
		
	}
}
