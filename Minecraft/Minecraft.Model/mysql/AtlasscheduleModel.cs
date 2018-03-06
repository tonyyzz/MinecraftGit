using System;
namespace Minecraft.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2018-03-06 09:06:08
	public partial class AtlasscheduleModel
	{
		/// <summary>
		/// 
		/// </summary>
		public AtlasscheduleModel()
		{
			PlayerId = 0;
			CurPosition = 0;
			DestPosition = 0;
			StartTime = new DateTime(1900, 1, 1);
		}
		/// <summary>
		/// PlayerId
		/// </summary>
		public int PlayerId { get; set; }
		/// <summary>
		/// 当期所在位置（一个地图下标，从配置表中获取）
		/// </summary>
		public int CurPosition { get; set; }
		/// <summary>
		/// 目的地所在位置（一个地图下标，值来源于配置表）
		/// </summary>
		public int DestPosition { get; set; }
		/// <summary>
		/// 前往目的地开始时间
		/// </summary>
		public DateTime StartTime { get; set; }
	}
}
