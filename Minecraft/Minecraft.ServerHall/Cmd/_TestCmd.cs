using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;

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
				return ProtocolHelper.GetProtocolStr(defCommand);
			}
		}

		private EnumCommand defCommand = EnumCommand.Test_TestCmd;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			//if (!session.minecraftSessionInfo.IsLogin)
			//{
			//	session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
			//	return;
			//}
			var req = requestInfo.GetRequestObj<TestReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}




			var resp = new TestResp
			{                                        
				PlayerId = req.PlayerId
			};
			session.Send(defCommand, resp);
		}
	}
}
