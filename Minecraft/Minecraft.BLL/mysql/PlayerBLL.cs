using Minecraft.CacheRedis;
using Minecraft.Config;
using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
	public class PlayerBLL : BaseBLL
	{
		private static RedisHelper redisHelper = new RedisHelper();
		public static PlayerModel GetSingleOrDefault(int playerId, out bool fromCache)
		{
			fromCache = false;
			var cacheModel = redisHelper.StringGet<PlayerModel>(MinecraftRedisKeyConfig.PlayerInfo + playerId);
			if (cacheModel != null)
			{
				fromCache = true;
				return cacheModel;
			}
			else
			{
				var model = PlayerDAL.GetSingleOrDefault(playerId);
				redisHelper.StringSet(MinecraftRedisKeyConfig.PlayerInfo + playerId, model, MinecraftCommonConfig.DefRedisExpiry);
				return model;
			}
		}
	}
}
