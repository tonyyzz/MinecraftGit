using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;

namespace Minecraft.ConnTest.Send
{
	public class SendGoodsInsert
	{
		public static MainCommand mainCommand = MainCommand.Goods;
		public static SecondCommand secondCommand = SecondCommand.Goods_GoodsInsert;
		public static (MainCommand, SecondCommand, object) GetReq()
		{
			var req = new GoodsInsertReq()
			{
				 PlayerId=2,
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
