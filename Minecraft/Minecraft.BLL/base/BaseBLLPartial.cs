using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL
{
	public partial class BaseBLL
	{
		/// <summary>
		/// 根据前缀删除表
		/// </summary>
		/// <param name="prefixName"></param>
		public static void DropTablesWithPrefix(string prefixName)
		{
			BaseDAL.DropTablesWithPrefix(prefixName);
		}
	}
}
