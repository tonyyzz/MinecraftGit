using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
	/// <summary>
	/// 分隔符配置
	/// </summary>
	public class SeparatorConfig
	{
		/// <summary>
		/// 数据库字段的值的分隔符
		/// </summary>
		public static string DbFieldVal = ",";
		/// <summary>
		/// 协议结束符
		/// </summary>
		public static string Protocol = "##";
		/// <summary>
		/// 黏包分隔符
		/// </summary>
		public static string StickyBag = "##";
		/// <summary>
		/// 传输符，与前端交互时，协议与data的分隔符
		/// </summary>
		public static string Transfer = " ";
	}
}

