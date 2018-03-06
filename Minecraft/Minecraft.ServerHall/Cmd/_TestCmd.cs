using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace Minecraft.ServerHall.Cmd
{
	/// <summary>
	/// 测试命令
	/// </summary>
	public class TestCmd : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Test;
		private SecondCommand defSecondCommand = SecondCommand.Test_TestCmd;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<TestReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(defMainCommand, defSecondCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}




			var resp = new TestResp
			{
				PlayerId = req.PlayerId
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
