using Minecraft.BLL.mongodb;
using Minecraft.Config;
using Minecraft.Model;
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
	public class PlayerBaseInsert : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Player;
		private SecondCommand defSecondCommand = SecondCommand.Player_PlayerBaseInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<PlayerBaseInsertReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_ParameterError, new MsgResp(MsgLevelEnum.Error, "参数错误"));
				return;
			}

			//PlayerbaseModel playerbaseModel = new PlayerbaseModel
			//{
			//	PlayerId = req.PlayerId,
			//	Fight_Attack = 1,
			//	Fight_AttackSpeed = 2,
			//	Fight_Defense = 3,
			//	Fight_TravelRate = 4,
			//	Human_Clean = 6,
			//	Human_GoToilet = 7,
			//	Human_Hunger = 9,
			//	Human_Life = 78,
			//};
			//playerbaseModel = PlayerbaseBLL.Insert(playerbaseModel);


			PlayerBaseInsertResp resp = new PlayerBaseInsertResp
			{
				PlayerId = req.PlayerId
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
