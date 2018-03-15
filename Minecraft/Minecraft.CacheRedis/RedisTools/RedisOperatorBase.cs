using Minecraft.CacheRedis;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTools
{
	public abstract class RedisOperatorBase : IDisposable
	{
		protected IRedisClient Redis { get; private set; }
		private bool _isDispose = false;
		public RedisOperatorBase()
		{
			//try
			//{
			//	Redis = RedisClientManager.GetClient();
			//}
			//finally
			//{
			//	Redis.Dispose();
			//}
			try
			{
				Redis = (RedisClient)RedisProvider.Provider.GetClient();
				// Do stuff
			}
			finally
			{
				Redis.Dispose();
			}

		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool dispose)
		{
			if (!this._isDispose)
			{

				Redis.Dispose();
				Redis = null;
			}
			this._isDispose = true;
		}

		public virtual void Save()
		{
			Redis.Save();
		}

		public virtual void SaveAsync()
		{
			Redis.SaveAsync();
		}
	}
}
