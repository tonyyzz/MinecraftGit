using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace Minecraft.ServerHall.Cmd
{
	public class BackpackGoodsInsert : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Backpack;
		private SecondCommand defSecondCommand = SecondCommand.Backpack_BackpackGoodsInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<PlayerBaseInsertReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_ParameterError, new MsgResp(MsgLevelEnum.Error, "参数错误"));
				return;
			}




			TestResp resp = new TestResp
			{
				PlayerId = req.PlayerId
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
