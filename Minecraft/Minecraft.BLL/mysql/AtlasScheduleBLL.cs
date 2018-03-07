using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class AtlasScheduleBLL : BaseBLL
	{
		private static RedisHelper redisHelper = new RedisHelper();
		public static bool InsertSuccess(AtlasscheduleModel model)
		{
			redisHelper.StringSet(RedisKeyConfig.AtlasSchedule + model.PlayerId, model, CommonConfig.DefRedisExpiry);
			return BaseBLL.InsertSuccess(model);
		}

		public static AtlasscheduleModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			var cacheModel = redisHelper.StringGet<AtlasscheduleModel>(RedisKeyConfig.AtlasSchedule + playerId);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = new AtlasscheduleModel();
				model = GetSingleOrDefault(model, (nameof(model.PlayerId), playerId));
				redisHelper.StringSet(RedisKeyConfig.AtlasSchedule + playerId, model, CommonConfig.DefRedisExpiry);
				return model;
			}
		}
	}
}
