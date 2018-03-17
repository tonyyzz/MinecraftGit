using Minecraft.BLL;
using Minecraft.BLL.mysql;
using Minecraft.Config;
using Minecraft.Config.Memory;
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
		static Init()
		{
			CSVConfig.Install();
		}

		private static int playerNum = 10;
		private static int size = 20;

		/// <summary>
		/// 执行初始化方法
		/// </summary>
		public static void Do()
		{
			Console.WriteLine("正在初始化数据...");
			TruncateTables();

			InitPlayerbasis();

			InitGoods();

			InitFriend();

			//InsertFriendData();
			InitBackpack();
			Console.WriteLine("数据初始化完成！");
		}

		private static void TruncateTables()
		{
			BaseBLL.TruncateTable(new PlayerbasisModel());
			BaseBLL.TruncateTable(new BackpackModel());
		}

		/// <summary>
		/// 初始化player基础数据
		/// </summary>
		private static void InitPlayerbasis()
		{
			List<PlayerbasisModel> list = new List<PlayerbasisModel>();
			for (int i = 1; i <= playerNum; i++)
			{
				//插入一条数据
				PlayerbasisModel model = new PlayerbasisModel
				{
					PlayerId = i,
					Name = $"Player_{i}",
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
				list.Add(model);
			}

			BaseBLL.BatchInsert(list);
		}

		private static void InitGoods()
		{
			BaseBLL.DropTablesWithPrefix(TablePrefixConfig.Goods);
		}
		private static void InitFriend()
		{
			BaseBLL.DropTablesWithPrefix(TablePrefixConfig.Friend);
		}

		/// <summary>
		/// 初始化朋友表数据
		/// </summary>
		public static void InsertFriendData()
		{
			var friendTableNameCacheList = new List<string>();

			for (int i = 1; i <= 10; i++)
			{
				for (int j = 1; j <= 10; j++)
				{

					var friendModel = new FriendModel()
					{
						PlayerId = i + 9995,
						FriendId = j,
						AddTime = DateTime.Now
					};
					FriendBLL.InsertSuccessForSplitTable(friendModel, friendTableNameCacheList);
					friendModel = new FriendModel()
					{
						PlayerId = j,
						FriendId = i + 9995,
						AddTime = DateTime.Now
					};
					FriendBLL.InsertSuccessForSplitTable(friendModel, friendTableNameCacheList);
				}
			}

		}

		class BackpackItem
		{
			/// <summary>
			/// 位置坐标
			/// </summary>
			public int SizePosition { get; set; }
			/// <summary>
			/// 物品itemid
			/// </summary>
			public string GoodsItemId { get; set; }
			/// <summary>
			/// 当前size中itemid的数量
			/// </summary>
			public int Count { get; set; }
		}

		public static void InitBackpack()
		{
			for (int p = 1; p <= playerNum; p++)
			{
				List<BackpackItem> itemList = new List<BackpackItem>();
				for (int i = 0; i < size; i++)
				{
					Random random = new Random(DateTimeHelper.GetTotalSecondsIntOfThisYear() + i);
					BackpackItem backpackItem = new BackpackItem
					{
						SizePosition = i,
						GoodsItemId = CSVConfig.itemsList[random.Next(CSVConfig.itemsList.Count())].Id,
						Count = random.Next(11),
					};
					var totalCount = itemList.Where(m => m.GoodsItemId == backpackItem.GoodsItemId).Sum(m => m.Count) + backpackItem.Count;
					if (totalCount <= 2)
					{
						itemList.Add(backpackItem);
					}
				}

				if (itemList != null && itemList.Any())
				{
					List<string> goodsIdList = new List<string>();
					itemList.ForEach(item =>
					{
						string goodsId = StringHelper.GetGuidStr();
						GoodsModel goodsModel = new GoodsModel
						{
							GoodsId = goodsId,
							BelongsTo = 1,
							GoodsItemId = item.GoodsItemId,
							PlayerId = p,
							WastageValue = 100,
							GoodsPosition = item.SizePosition,
						};
						goodsIdList.Add(goodsId);
						GoodsBLL.InsertSuccessForSplitTable(goodsModel, MemorySystemManager.goodsTableNameCacheList);
					});
					BackpackModel backpackModel = new BackpackModel
					{
						PlayerId = p,
						Size = size,
						GoodsIds = string.Join(SeparatorConfig.DbFieldVal, goodsIdList),
					};
					BaseBLL.InsertSuccess(backpackModel);

				}

				int f = 9;
			}
		}
	}
}
