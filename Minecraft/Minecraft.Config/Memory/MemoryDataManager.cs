using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config.Memory
{
	/// <summary>
	/// 内存数据管理类
	/// </summary>
	public class MemoryDataManager
	{
		/// <summary>
		/// 玩家基础数据
		/// </summary>
		private static List<PlayerbasisModel> playerbasisList = new List<PlayerbasisModel>();


		public static void UpdatePlayerbasis(PlayerbasisModel playerbasisModel)
		{
			var playerbasis = playerbasisList.FirstOrDefault(m => m.PlayerId == playerbasisModel.PlayerId);
			if (playerbasis != null)
			{
				playerbasis = playerbasisModel;
			}
			else
			{
				playerbasisList.Add(playerbasisModel);
			}
		}
	}
}
