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
		public static MainCommand mainCommand = MainCommand.Backpack;
		public static SecondCommand secondCommand = SecondCommand.Backpack_BackpackGoodsInsert;
		public static (MainCommand, SecondCommand, object) GetReq()
		{
			var req = new BackpackGoodsInsertReq()
			{
				PlayerId = 1
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
