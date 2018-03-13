using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	/// <summary>
	/// 发送测试
	/// </summary>
	public class SendTestCmd
	{
		public static EnumCommand command = EnumCommand.Test_TestCmd;
		public static CommandReq<TestReq> GetReq()
		{
			var req = new TestReq()
			{
				PlayerId = 1
			};
			return new CommandReq<TestReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
