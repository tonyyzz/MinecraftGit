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
		public static MainCommand mainCommand = MainCommand.Friend;
		public static SecondCommand secondCommand = SecondCommand.Friend_FriendInsert;
		public static (MainCommand, SecondCommand, FriendInsertReq) GetReq()
		{
			var req = new FriendInsertReq()
			{
				FriendId = 1
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
