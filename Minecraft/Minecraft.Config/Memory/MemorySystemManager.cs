using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config.Memory
{
	/// <summary>
	/// 系统缓存处理类（面向系统全局）
	/// </summary>
	public class MemorySystemManager
	{
		/// <summary>
		/// 动态缓存已经存在的goods表，如果查询过已经存在goods表，则缓存到这里
		/// </summary>
		public volatile static List<string> goodsTableNameCacheList = new List<string>();
		/// <summary>
		/// 动态缓存已经存在的friend表，如果查询过已经存在friend表，则缓存到这里
		/// </summary>
		public volatile static List<string> friendTableNameCacheList = new List<string>();
	}
}
