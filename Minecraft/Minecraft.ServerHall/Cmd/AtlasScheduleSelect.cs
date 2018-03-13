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
				return ProtocolHelper.GetProtocolStr(defCommand);
			}
		}

		private EnumCommand defCommand = EnumCommand.AtlasSchedule_AtlasScheduleSelect;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<AtlasScheduleSelectReq>(session);
			if (req == null)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}

			var model = AtlasScheduleBLL.GetSingleOrDefault(session.minecraftSessionInfo.player.PlayerId, out bool fromCache);
			if (model == null)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "不存在" });
				return;
			}

			var resp = new AtlasScheduleSelectResp
			{
			};
			session.Send(defCommand, resp);
		}
	}
}
