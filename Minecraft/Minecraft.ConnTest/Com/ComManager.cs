using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ConnTest.Com
{
	public class ComManager
	{
		public static Socket socketClient = null;

		public static void Send(Socket socketClient,
			Func<(MainCommand, SecondCommand, object)> func,
			Action afterAction = null)
		{
			var (mainCommand, secondCommand, req) = func();
			var protocolStr = ProtocolHelper.GetProtocolStr(mainCommand, secondCommand);
			string cont = req.JsonSerialize();
			var sendContent = CustomEncrypt.Encrypt(cont);
			var buffter = Encoding.UTF8.GetBytes($"{protocolStr} {sendContent}##");
			socketClient.Send(buffter);

			afterAction?.Invoke();


		}
	}
}
