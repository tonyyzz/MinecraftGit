using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Minecraft.BLL.mysql
{
	public class PlayerbasisBLL : BaseBLL
	{
		private static RedisHelper redisHelper = new RedisHelper();
		public static PlayerbasisModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			var cacheModel = redisHelper.StringGet<PlayerbasisModel>(RedisKeyConfig.PlayerInfo + playerId);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new PlayerbasisModel();
				model = BaseDAL.GetSingleOrDefault(model, (nameof(model.PlayerId), playerId));
				redisHelper.StringSet(RedisKeyConfig.PlayerInfo + playerId, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}

		public static bool Update(PlayerbasisModel model)
		{
			return BaseDAL.Update(model, nameof(model.PlayerId));
		}
	}
}
