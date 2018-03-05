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
		public void Execute(MainCommand mainCommand, SecondCommand secondCommand, string respStr)
		{
			var resp = respStr.JsonDeserialize<MsgResp>();
			if (resp == null || resp.InfoLevel != MsgLevelEnum.Info)
			{
				return;
			}
		}
	}
}
