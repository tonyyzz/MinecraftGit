﻿using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.InitTest
{
	public class Init
	{
		/// <summary>
		/// 执行初始化方法
		/// </summary>
		public static void Do()
		{
			Console.WriteLine("正在初始化数据...");
			//TruncateTables();
			InitPlayerbasis();
			//InitGoods();
			//InitFriend();
			Console.WriteLine("数据初始化完成！");
		}

		private static void TruncateTables()
		{
			BaseBLL.TruncateTable(new PlayerbasisModel());
		}

		/// <summary>
		/// 初始化player基础数据
		/// </summary>
		private static void InitPlayerbasis()
		{
			//插入一条数据
			PlayerbasisModel playerbasisModel = new PlayerbasisModel
			{
				PlayerId = 10001,
				Name = "Player_1",
				PhysicalStrengthValue = 100,
				Fight_Attack = 10,
				Exp = 0,
				Fight_AttackSpeed = 10,
				Fight_Defense = 10,
				Fight_TravelRate = 10,
				GoldCoin = 0,
				Human_Clean = 0,
				Human_GoToilet = 0,
				Human_Hunger = 100,
				Human_Life = 100,
			};
			BaseBLL.Insert(playerbasisModel);
		}

		private static void InitGoods()
		{
			BaseBLL.DropTablesWithPrefix(TablePrefixConfig.Goods);
		}
		private static void InitFriend()
		{
			BaseBLL.DropTablesWithPrefix(TablePrefixConfig.Friend);
		}
	}
}
