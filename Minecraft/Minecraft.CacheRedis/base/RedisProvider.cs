
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.CacheRedis
{
    using RedisTools;
    public class RedisProvider
    {
        public PooledRedisClientManager Pool { get; set; }
        private RedisProvider()
        {
            var writeServerList = RedisConfig.Current.WriteServerList.Split(',');
            var readServerList = RedisConfig.Current.ReadServerList.Split(',');
           // var srv = new List<string> { $"{Configs.Server}:{Configs.Port}" };

            Pool= new PooledRedisClientManager(writeServerList, readServerList,
                                         new RedisClientManagerConfig
                                         {
                                             MaxWritePoolSize = RedisConfig.Current.MaxWritePoolSize,
                                             MaxReadPoolSize = RedisConfig.Current.MaxReadPoolSize,
                                             AutoStart = RedisConfig.Current.AutoStart,
                                         });
        }

        public IRedisClient GetClient()
        {
            try
            {
                var connection = (RedisClient)Pool.GetClient();
                return connection;
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        private static RedisProvider _instance;
        public static object _providerLock = new object();
        public static RedisProvider Provider
        {
            get
            {
                lock (_providerLock)
                {
                    if (_instance == null)
                    {
                        var instance = new RedisProvider();
                        _instance = instance;
                        return _instance;
                    }
                    else
                    {

                        return _instance;
                    }
                }
            }
        }

    }
}
