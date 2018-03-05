using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model;
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
	public class GoodsInsert : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defMainCommand, defSecondCommand);
			}
		}

		private MainCommand defMainCommand = MainCommand.Goods;
		private SecondCommand defSecondCommand = SecondCommand.Goods_GoodsInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			var req = requestInfo.GetRequestObj<GoodsInsertReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(MainCommand.Error, SecondCommand.Error_ParameterError, new MsgResp(MsgLevelEnum.Error, "参数错误"));
				return;
			}

			GoodsModel goodsModel = new GoodsModel
			{
				GoodsId = StringHelper.GetGuidStr(),
				PlayerId = req.PlayerId,
				BelongsTo = 1,
				GoodsItemId = 2,
				GoodsPosition = 0,
				WastageValue = 100,
			};

			var flag = GoodsBLL.InsertSuccessGoodsModel(goodsModel, MemorySystemManager.goodsTableList);
			GoodsInsertResp resp = new GoodsInsertResp
			{
				IsSuccess = flag
			};
			session.Send(defMainCommand, defSecondCommand, resp);
		}
	}
}
