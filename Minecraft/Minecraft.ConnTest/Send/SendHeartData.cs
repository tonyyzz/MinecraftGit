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
		public static MainCommand mainCommand = MainCommand.Heart;
		public static SecondCommand secondCommand = SecondCommand.Heart_HeartData;
		public static (MainCommand, SecondCommand, HeartDataReq) GetReq()
		{
			var req = new HeartDataReq()
			{
				StrEncrypted = EncryptHelper.Encrypt(MinecraftConfiguration.HeartDataReqSecretKey + " " + DateTime.Now.Ticks)
			};
			return (mainCommand, secondCommand, req);
		}
	}
}
