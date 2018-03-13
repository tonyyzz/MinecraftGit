using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Config;
using Minecraft.Model.ReqResp;

namespace Minecraft.ConnTest.Send
{
	public class SendFriendInsert
	{
		public static EnumCommand command = EnumCommand.Friend_FriendInsert;
		public static CommandReq<FriendInsertReq> GetReq()
		{
			var req = new FriendInsertReq()
			{
				FriendId = 2
			};
			return new CommandReq<FriendInsertReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
