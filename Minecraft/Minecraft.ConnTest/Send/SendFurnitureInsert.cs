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
		public static MainCommand mainCommand = MainCommand.Furniture;
		public static SecondCommand secondCommand = SecondCommand.Furniture_FurnitureInsert;
		public static (MainCommand, SecondCommand, object) GetReq()
		{
			var req = new FurnitureInsertReq()
			{
				PlayerId = 1
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
