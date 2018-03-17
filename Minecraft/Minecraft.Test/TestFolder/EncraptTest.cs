using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test.TestFolder
{
	public class EncraptTest
	{
		public static void Do()
		{
			int PlayerId = 1;
			var goodsModelList = GoodsBLL.GetListAll(PlayerId, 1, out bool fromCache);
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

			EnumCommand defCommand = EnumCommand.Backpack_BackpackGoodsSelect;


			string protocolStr = ProtocolHelper.GetProtocolStr(defCommand);

			string str = protocolStr + SeparatorConfig.Transfer + resp.JsonSerialize();

			string encreStr = EncryptHelper.Encrypt(str);
			string deStr = EncryptHelper.Decrypt(encreStr,"test");

			string fff = "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";
			var  strtrtr= EncryptHelper.Decrypt(fff, "test");

		}
	}
}
