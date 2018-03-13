using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;

namespace Minecraft.ConnTest.Send
{
	public class SendFriendListSelect
	{
		public static EnumCommand command = EnumCommand.Friend_FriendListSelect;
		public static CommandReq<FriendListSelectReq> GetReq()
		{
			var req = new FriendListSelectReq()
			{
				
			};
			return new CommandReq<FriendListSelectReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
