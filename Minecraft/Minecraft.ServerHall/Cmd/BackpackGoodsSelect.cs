using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Minecraft.ServerHall.Cmd
{
	public class BackpackGoodsSelect : CommandBase<MinecraftSession, StringRequestInfo>
	{
		public override string Name
		{
			get
			{
				return ProtocolHelper.GetProtocolStr(defCommand);
			}
		}

		private EnumCommand defCommand = EnumCommand.Backpack_BackpackGoodsSelect;
		public override void ExecuteCommand(MinecraftSession session, StringRequestInfo requestInfo)
		{
			if (!session.minecraftSessionInfo.IsLogin)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "未登录" });
				return;
			}
			var req = requestInfo.GetRequestObj<BackpackGoodsSelectReq>(session);
			if (req == null)
			{
				session.Send(defCommand, new BaseResp { RespLevel = RespLevelEnum.Error, Msg = "参数错误" });
				return;
			}
			var goodsModelList = GoodsBLL.GetListAll(session.minecraftSessionInfo.player.PlayerId, 1, out bool fromCache);

			var goodsList = new List<GoodsInfo>();
			if (goodsModelList != null && goodsModelList.Any())
			{
				var goodsInfo = new GoodsInfo();
				goodsModelList.ForEach(item =>
				{
					goodsList.Add(new GoodsInfo
					{
						BelongsTo = item.BelongsTo,
						GoodsId = item.GoodsId,
						GoodsItemId = item.GoodsItemId,
						GoodsPosition = item.GoodsPosition,
						PlayerId = item.PlayerId,
						WastageValue = item.WastageValue
					});
				});
			}
			var resp = new BackpackGoodsSelectResp
			{
				goodsList = goodsList
			};
			session.Send(defCommand, resp);
		}
	}
}
