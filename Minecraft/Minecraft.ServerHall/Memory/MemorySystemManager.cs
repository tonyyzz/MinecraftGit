using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.ServerHall.Memory
{
	/// <summary>
	/// 系统缓存处理类（面向系统全局）
	/// </summary>
	public class MemorySystemManager
	{
		/// <summary>
		/// 已经存在的goods表，如果查询过已经存在goods表，则缓存到这里
		/// </summary>
		public static List<string> goodsTableList = new List<string>();
	}
}
