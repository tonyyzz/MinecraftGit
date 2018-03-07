using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace Minecraft.ServerHall.Cmd
{
	public class AtlasScheduleInsert : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.AtlasSchedule;
		private SecondCommand defSecondCommand = SecondCommand.AtlasSchedule_AtlasScheduleInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<AtlasScheduleInsertReq>(session);
			if (req == null)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}


			AtlasscheduleModel atlasscheduleModel = new AtlasscheduleModel
			{
				PlayerId = session.minecraftSessionInfo.player.PlayerId,
				StartTime = DateTime.Now,
				CurPosition = 0,
				DestPosition = 1,
			};
			var flag = AtlasScheduleBLL.InsertSuccess(atlasscheduleModel);
			if (!flag)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "操作失败" });
				return;
			}


			var resp = new AtlasScheduleInsertResp
			{
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
