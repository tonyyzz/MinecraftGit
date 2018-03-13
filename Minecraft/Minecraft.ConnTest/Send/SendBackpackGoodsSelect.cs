using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Minecraft.ConnTest.Send
{
	public class SendBackpackGoodsSelect
	{
		public static EnumCommand command = EnumCommand.Backpack_BackpackGoodsSelect;
		public static CommandReq<BackpackGoodsSelectReq> GetReq()
		{
			var req = new BackpackGoodsSelectReq()
			{
			};
			return new CommandReq<BackpackGoodsSelectReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
