using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace Minecraft.ServerHall.Cmd
{
	public class FriendListSelect : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Friend;
		private SecondCommand defSecondCommand = SecondCommand.Friend_FriendListSelect;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<FriendListSelectReq>(session);
			if (req == null)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}

			var friendList = FriendBLL.GetListAll(session.minecraftSessionInfo.player.PlayerId);


			var resp = new FriendListSelectResp
			{
				PlayerId = session.minecraftSessionInfo.player.PlayerId
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
