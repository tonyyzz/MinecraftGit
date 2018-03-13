using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config.ipConst
{
	/// <summary>
	/// Ip常亮配置
	/// </summary>
	public class IpConstConfig
	{
		public static Dictionary<string, string> IpConstDict = new Dictionary<string, string>();
		public static void Init()
		{
			IpConstDict = GetConstConfigDict();
		}
		private static Dictionary<string, string> GetConstConfigDict()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string path = Path.Combine("ipConst", "ipConfig.txt");
			var lines = File.ReadLines(path).ToList();
			if (lines != null && lines.Any())
			{
				foreach (var item in lines)
				{
					var items = item.Split(',');
					dictionary.Add($"192.168.0.{items[0]}", items[1]);
				}
			}
			return dictionary;
		}

		public static string GetIpUserNameTipStr(string ipAddr)
		{
			string ipUserNameTipStr = "";
			var kvPair = IpConstConfig.IpConstDict.FirstOrDefault(m => m.Key == ipAddr);
			if (!kvPair.Value.IsNullOrWhiteSpace())
			{
				ipUserNameTipStr = $"【所属：{kvPair.Value}】";
			}
			return ipUserNameTipStr;
		}

	}
}
