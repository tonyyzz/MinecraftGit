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
		public static string GetProtocolStr(EnumCommand secondCommand)
		{
			return ((int)secondCommand).ToString().PadLeft(ProtocolLen.Length, '0');

		}

		/// <summary>
		/// 根据协议字符串得到协议枚举
		/// </summary>
		/// <param name="protocolStr"></param>
		/// <returns></returns>
		public static EnumCommand GetCommand(string protocolStr)
		{
			return (EnumCommand)Convert.ToInt32(protocolStr);
		}
	}
}
