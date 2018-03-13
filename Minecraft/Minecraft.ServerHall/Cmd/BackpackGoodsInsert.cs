using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Config.Memory;
using Minecraft.Model;
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
				return ProtocolHelper.GetProtocolStr(defCommand);
			}
		}

		private EnumCommand defCommand = EnumCommand.Backpack_BackpackGoodsInsert;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<BackpackGoodsInsertReq>(session);
			if (req == null || req.PlayerId <= 0)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}

			GoodsModel goodsModel = new GoodsModel
			{
				GoodsId = StringHelper.GetGuidStr(),
				PlayerId = req.PlayerId,
				BelongsTo = 1,
				GoodsItemId = "1",
				GoodsPosition = 0,
				WastageValue = 100
			};
			var flag = GoodsBLL.InsertSuccessForSplitTable(goodsModel, MemorySystemManager.goodsTableNameCacheList);
			if (!flag)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "goods分表插入操作失败" });
				return;
			}

			var resp = new BackpackGoodsInsertResp
			{
				PlayerId = req.PlayerId
			};
			session.Send(defCommand, resp);
		}
	}
}
