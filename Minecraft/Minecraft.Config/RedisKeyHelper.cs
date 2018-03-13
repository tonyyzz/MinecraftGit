using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public class RedisKeyHelper
	{
		/// <summary>
		/// 获取redisKeyName
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		public static string GetRedisKeyName(params string[] keys)
		{
			if (keys == null || !keys.Any())
			{
				throw new ArgumentException("参数错误");
			}
			return string.Join("_", keys);
		}
	}
}
