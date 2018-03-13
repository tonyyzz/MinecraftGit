using Minecraft.Config;
using Minecraft.Model.ReqResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Send
{
	public class SendHeartData
	{
		public static EnumCommand command = EnumCommand.Heart_HeartData;
		public static CommandReq<HeartDataReq> GetReq()
		{
			var req = new HeartDataReq()
			{
				StrEncrypted = EncryptHelper.Encrypt(MinecraftConfiguration.HeartDataReqSecretKey + " " + DateTime.Now.Ticks)
			};
			return new CommandReq<HeartDataReq>
			{
				Command = command,
				Req = req
			};
		}
	}
}
