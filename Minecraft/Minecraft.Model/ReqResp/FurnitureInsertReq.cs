using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Model.ReqResp
{
	/// <summary>
	/// 家具插入请求实体
	/// </summary>
	public class FurnitureInsertReq : BaseReq
	{
		public int PlayerId { get; set; }
	}
}
