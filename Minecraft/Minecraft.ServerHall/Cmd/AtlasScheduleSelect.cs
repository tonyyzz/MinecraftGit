using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace Minecraft.ServerHall.Cmd
{
	public class AtlasScheduleSelect : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.AtlasSchedule;
		private SecondCommand defSecondCommand = SecondCommand.AtlasSchedule_AtlasScheduleSelect;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<AtlasScheduleSelectReq>(session);
			if (req == null)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}

			var model = AtlasScheduleBLL.GetSingleOrDefault(session.minecraftSessionInfo.player.PlayerId, out bool fromCache);
			if (model == null)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "不存在" });
				return;
			}

			var resp = new AtlasScheduleSelectResp
			{
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
