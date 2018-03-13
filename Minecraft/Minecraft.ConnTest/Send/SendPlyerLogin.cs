using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	public class SendPlyerLogin
	{
		public static EnumCommand command = EnumCommand.Player_PlayerLogin;
		public static CommandReq<PlayerLoginReq> GetReq()
		{
			var req = new PlayerLoginReq()
			{
				PlayerId = 1
			};
			return new CommandReq<PlayerLoginReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
