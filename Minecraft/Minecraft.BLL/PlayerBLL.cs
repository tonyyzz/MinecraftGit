using GoStopProxy.Model;
using Minecraft.DALMySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.BLL
{
    public class PlayerBLL:BaseBLL
    {
        public static PlayerModel GetSingleOrDefault(int playerId)
        {
            return PlayerDAL.GetSingleOrDefault(playerId);
        }
    }
}
