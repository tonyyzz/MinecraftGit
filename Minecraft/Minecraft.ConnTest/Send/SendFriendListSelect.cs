using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;

namespace Minecraft.ConnTest.Send
{
	public class SendFriendListSelect
	{
		public static MainCommand mainCommand = MainCommand.Friend;
		public static SecondCommand secondCommand = SecondCommand.Friend_FriendListSelect;
		public static (MainCommand, SecondCommand, FriendListSelectReq) GetReq()
		{
			var req = new FriendListSelectReq()
			{
				
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
