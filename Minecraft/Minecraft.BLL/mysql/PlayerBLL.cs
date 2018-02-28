using Minecraft.DALMySql;
using Minecraft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL.mysql
{
    public class PlayerBLL:BaseBLL
    {
        public static PlayerModel GetSingleOrDefault(int playerId)
        {
            return PlayerDAL.GetSingleOrDefault(playerId);
        }
    }
}
