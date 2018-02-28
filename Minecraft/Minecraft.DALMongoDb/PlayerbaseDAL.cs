using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.DALMongoDb
{
	public class PlayerbaseDAL
	{
		private static MgHelper<PlayerbaseModel> mg = new MgHelper<PlayerbaseModel>();

		public static PlayerbaseModel Insert(PlayerbaseModel playerbaseModel)
		{
			return mg.Insert(playerbaseModel);
		}
	}
}
