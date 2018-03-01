﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	public static class MinecraftCommonConfig
	{
		/// <summary>
		/// 默认编码
		/// </summary>
		public static Encoding DefEncoding = Encoding.UTF8;
		/// <summary>
		/// 结束符
		/// </summary>
		public static string EndingSymbol = "##";

		/// <summary>
		/// 协议与数据包的分隔符
		/// </summary>
		public static char SeparativeSymbol = ' ';

		/// <summary>
		/// 默认redis缓存过期时间
		/// </summary>
		public static TimeSpan DefRedisExpiry = new TimeSpan(1, 0, 0); 


	}
}