using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Config;
using Minecraft.Model.ReqResp;

namespace Minecraft.ConnTest.Send
{
	public class SendAtlasScheduleSelect
	{
		public static MainCommand mainCommand = MainCommand.AtlasSchedule;
		public static SecondCommand secondCommand = SecondCommand.AtlasSchedule_AtlasScheduleSelect;
		public static (MainCommand, SecondCommand, AtlasScheduleSelectReq) GetReq()
		{
			var req = new AtlasScheduleSelectReq()
			{
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
