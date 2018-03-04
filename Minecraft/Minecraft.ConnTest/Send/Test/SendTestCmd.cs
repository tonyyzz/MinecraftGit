using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send.Test
{
	/// <summary>
	/// 发送测试
	/// </summary>
	public class SendTestCmd
	{
		public static MainCommand mainCommand = MainCommand.Test;
		public static SecondCommand secondCommand = SecondCommand.Test_TestCmd;
		public static (MainCommand, SecondCommand, object) GetReq()
		{
			TestReq req = new TestReq()
			{
				PlayerId = 1
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
