using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
    public static class ProtocolLen {
        public const int Main = 3;
        public const int Second = 5;
    }

    public enum MainCommand
    {
        TestCmd = 1,
    }

    public enum SecondCommand
    {
        TestCmd_Test = 1,
    }
}
