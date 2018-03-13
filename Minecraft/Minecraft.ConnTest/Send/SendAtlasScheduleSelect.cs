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
		public static EnumCommand command = EnumCommand.AtlasSchedule_AtlasScheduleSelect;
		public static CommandReq<AtlasScheduleSelectReq> GetReq()
		{
			var req = new AtlasScheduleSelectReq()
			{
			};
			return new CommandReq<AtlasScheduleSelectReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
