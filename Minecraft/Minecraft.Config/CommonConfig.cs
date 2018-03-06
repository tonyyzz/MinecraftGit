using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public static class CommonConfig
	{
		/// <summary>
		/// 默认编码
		/// </summary>
		public static Encoding DefEncoding = Encoding.UTF8;

		/// <summary>
		/// 默认redis缓存过期时间
		/// </summary>
		public static TimeSpan DefRedisExpiry = new TimeSpan(1, 0, 0);

		/// <summary>
		/// 得到表名称的后缀
		/// </summary>
		/// <param name="playerId"></param>
		/// <param name="submeterLen"></param>
		/// <returns></returns>
		public static int GetTablePostfix(int playerId, int submeterLen)
		{
			return ((playerId - 1) / submeterLen) * submeterLen + submeterLen;
		}
	}
}
