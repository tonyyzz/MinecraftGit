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
		public static EnumCommand command = EnumCommand.AtlasSchedule_AtlasScheduleInsert;
		public static CommandReq<AtlasScheduleInsertReq> GetReq()
		{
			var req = new AtlasScheduleInsertReq()
			{
			};
			return new CommandReq<AtlasScheduleInsertReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
