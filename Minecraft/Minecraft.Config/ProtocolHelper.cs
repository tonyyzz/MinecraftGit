using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class ProtocolHelper
	{
		public static string GetProtocolStr(MainCommand mainCommand, SecondCommand secondCommand)
		{
			return $"{((int)mainCommand).ToString().PadLeft(ProtocolLen.Main, '0')}" +
				   $"{((int)secondCommand).ToString().PadLeft(ProtocolLen.Second, '0')}";

		}

		/// <summary>
		/// 根据协议字符串得到协议枚举
		/// </summary>
		/// <param name="protocolStr"></param>
		/// <returns></returns>
		public static (MainCommand, SecondCommand) GetCommand(string protocolStr)
		{
			var mainStr = protocolStr.Substring(0, ProtocolLen.Main);
			var secondStr = protocolStr.Substring(ProtocolLen.Main);

			int mainInt = Convert.ToInt32(mainStr);
			int secondInt = Convert.ToInt32(secondStr);

			MainCommand mainCommand = (MainCommand)mainInt;
			SecondCommand secondCommand = (SecondCommand)secondInt;
			return (mainCommand, secondCommand);
		}
	}
}
