using Minecraft.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
    public class ProtocolHelper
    {
        public static string GetProtocolStr(MainCommand mainCommand, SecondCommand secondCommand)
        {
            return $"{((int)mainCommand).ToString().PadLeft(ProtocolLen.Main, '0')}" +
                   $"{((int)secondCommand).ToString().PadLeft(ProtocolLen.Second, '0')}";

        }
    }
}
