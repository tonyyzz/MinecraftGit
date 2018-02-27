using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = (int)TestEnum.C;
        }

        enum TestEnum
        {
            A = 1,
            B,
            C,
            D,
            F = 1
        }
    }
}
