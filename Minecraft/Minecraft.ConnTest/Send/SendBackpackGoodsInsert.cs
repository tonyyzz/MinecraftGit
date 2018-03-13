using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Config;
using Minecraft.Model.ReqResp;
namespace Minecraft.ConnTest.Send
{
	public class SendBackpackGoodsInsert
	{
		public static EnumCommand command = EnumCommand.Backpack_BackpackGoodsInsert;
		public static CommandReq<BackpackGoodsInsertReq> GetReq()
		{
			var req = new BackpackGoodsInsertReq()
			{
				PlayerId = 1
			};
			return new CommandReq<BackpackGoodsInsertReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
