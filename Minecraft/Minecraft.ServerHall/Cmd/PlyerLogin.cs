using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using Minecraft.ServerHall.Memory;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Cmd
{
	/// <summary>
	/// 玩家登录
	/// </summary>
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
		private SecondCommand defSecondCommand = SecondCommand.Player_PlayerLogin;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<PlayerLoginReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_ParameterError, new MsgResp(MsgLevelEnum.Error, "参数错误"));
				return;
			}
			var player = PlayerbasisBLL.GetSingleOrDefault(req.PlayerId, out bool fromCache);
			if (player == null)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_NotExist, new MsgResp(MsgLevelEnum.Error, "信息不存在"));
				return;
			}

			//登录成功
			session.minecraftSessionInfo.IsLogin = true;
			session.minecraftSessionInfo.LastLoginTime = DateTime.Now;
			session.minecraftSessionInfo.player = player;

			MemoryDataManager.UpdatePlayerbasis(player);

			//暂定
			var resp = player.JsonSerialize().JsonDeserialize<PlayerLoginResp>();

			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
