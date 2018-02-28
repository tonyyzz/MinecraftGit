using Minecraft.DALMongoDb;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mongodb
{
	public class PlayerbaseBLL
	{
		public static PlayerbaseModel Insert(PlayerbaseModel playerbaseModel)
		{
			return PlayerbaseDAL.Insert(playerbaseModel);
		}
	}
}
