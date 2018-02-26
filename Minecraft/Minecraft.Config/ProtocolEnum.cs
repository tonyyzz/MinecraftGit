using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Config
{
    public static class ProtocolLen
    {
        public const int Main = 3;
        public const int Second = 5;
    }

    public enum MainCommand
    {
        Test = 1, //测试
        Conn = 2, //连接
        Error = 3,
    }

    public enum SecondCommand
    {
        //测试
        Test_Test = 1001,

        //连接
        Conn_Success = 2001,

        //错误
        Error_ApplicationErrot = 3001,
        Error_UnknowRequest,
    }
}
