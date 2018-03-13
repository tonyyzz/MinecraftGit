using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTools
{

    /// <summary>
    /// 连接管理器
    /// </summary>
    public class RedisClientManager
    {
        private static PooledRedisClientManager _pooled;

        #region 创建链接池
        /// <summary>
        /// 创建链接池
        /// </summary>
        private static void CreateManager()
        {
            if (_pooled == null)
            {
                lock (new object())
                {

                    if (_pooled == null)
                    {
                        var writeServerList = RedisConfig.Current.WriteServerList.Split(',');
                        var readServerList = RedisConfig.Current.ReadServerList.Split(',');

                        _pooled = new PooledRedisClientManager(writeServerList, readServerList,
                                         new RedisClientManagerConfig
                                         {
                                             MaxWritePoolSize = RedisConfig.Current.MaxWritePoolSize,
                                             MaxReadPoolSize = RedisConfig.Current.MaxReadPoolSize,
                                             AutoStart = RedisConfig.Current.AutoStart,
                                         });
                    };
                }

            }
        }
        #endregion

        public static IRedisClient GetClient()
        {

            if (_pooled == null)
                CreateManager();
            return _pooled.GetClient();

        }
    }
}
