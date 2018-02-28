using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using Minecraft.Model.ReqResp.Player;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd.Player
{
	public class PlyerLogin : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Player;
		private SecondCommand defSecondCommand = SecondCommand.Player_Login;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<PlayerLoginReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_ParameterError, new MsgResp(MsgLevelEnum.Error, "参数错误"));
				return;
			}

			var player = PlayerBLL.GetSingleOrDefault(req.PlayerId);
			if (player == null)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_NotExist, new MsgResp(MsgLevelEnum.Error, "信息不存在"));
				return;
			}

			//登录成功
			session.minecraftSessionInfo.IsLogin = true;
			session.minecraftSessionInfo.LastLoginTime = DateTime.Now;
			session.minecraftSessionInfo.player = player;

			PlayerLoginResp resp = new PlayerLoginResp
			{
				PlayerId = player.PlayerId,
				Pwd = player.Pwd,
				exp = player.exp,
				CompetitiveCurrency = player.CompetitiveCurrency,
				diamond = player.diamond,
				MinkName = player.MinkName,
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
