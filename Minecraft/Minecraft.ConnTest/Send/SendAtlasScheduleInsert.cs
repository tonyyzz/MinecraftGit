using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	public class SendAtlasScheduleInsert
	{
		public static MainCommand mainCommand = MainCommand.AtlasSchedule;
		public static SecondCommand secondCommand = SecondCommand.AtlasSchedule_AtlasScheduleInsert;
		public static (MainCommand, SecondCommand, AtlasScheduleInsertReq) GetReq()
		{
			var req = new AtlasScheduleInsertReq()
			{
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
