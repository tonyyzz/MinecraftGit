using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	public class SendFurnitureInsert
	{
		public static EnumCommand command = EnumCommand.Furniture_FurnitureInsert;
		public static CommandReq<FurnitureInsertReq> GetReq()
		{
			var req = new FurnitureInsertReq()
			{
				PlayerId = 1
			};
			return new CommandReq<FurnitureInsertReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
