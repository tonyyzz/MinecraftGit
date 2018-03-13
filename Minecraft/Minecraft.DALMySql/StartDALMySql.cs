using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.DALMySql
{
	public class StartDALMySql:BaseDAL
	{
		public static bool StartMySqlCheck()
		{
			bool canStart = false;
			try
			{
				using (var Conn = GetConn())
				{
					Conn.Open();
					canStart = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("【mysql】异常：" + ex.ToString());
			}
			return canStart;
		}
	}
}
