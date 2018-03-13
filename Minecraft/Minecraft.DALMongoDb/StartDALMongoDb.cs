using Minecraft.Model.mongodb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.DALMongoDb
{
	public class StartDALMongoDb
	{
		public static bool StartMongoDbCheck()
		{
			bool canStart = false;
			try
			{
				MgHelper<MongoDbTestModel> mg = new MgHelper<MongoDbTestModel>();
				mg.QueryOne("1");
				canStart = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("【mongodb】异常：" + ex.ToString());
			}
			return canStart;
		}
	}
}
