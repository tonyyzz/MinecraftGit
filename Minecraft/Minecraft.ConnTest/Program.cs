using Minecraft.Config;
using Minecraft.Model.ReqResp.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft.ConnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = IPAddress.Parse("111.230.142.94");
            IPEndPoint point = new IPEndPoint(ip, 2017);
            //进行连接
            socketClient.Connect(point);

            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("是否链接：" + socketClient.Connected);
            //        Thread.Sleep(1000);

            //    }

            //});



            //不停的接收服务器端发送的消息
            Thread thread = new Thread(Recive)
            {
                IsBackground = true
            };
            thread.Start(socketClient);

            var protocolStr = ProtocolHelper.GetProtocolStr(MainCommand.Player, SecondCommand.Player_Login);



            PlayerLoginRequest playerLoginRequest = new PlayerLoginRequest()
            {
                PlayerId = 1
            };
            var sendContent = CustomEncrypt.Encrypt(playerLoginRequest.JsonSerialize());

            var buffter = Encoding.UTF8.GetBytes($"{protocolStr} {sendContent}##");
            //var buffter = Encoding.UTF8.GetBytes($"01 构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台机构建5000个连接的请求测试(测试电脑是一台笔记本),请求消息大小为1K;构建一个简单的TCP服务,然后在另一台\r\n");
            //CountSpliterReceiveFilter - 固定数量分隔符协议
            //var buffter = Encoding.UTF8.GetBytes($" ECHO#part1#part2#part3#part4#part5#part6#{i}#");
            //var buffter = Encoding.ASCII.GetBytes($"KILL BILL");
            var temp = socketClient.Send(buffter);

            Console.WriteLine("消息发送成功");
            Console.ReadKey();
        }
        static void Recive(object o)
        {
            var send = o as Socket;
            while (true)
            {
                //获取发送过来的消息
                byte[] buffer = new byte[1024 * 1024 * 2];
                var effective = send.Receive(buffer);
                if (effective == 0)
                {
                    break;
                }
                //var bytes = buffer.ToList().Take(effective).ToArray();
                //CustomDE.Decrypt(bytes, 0, bytes.Length);

                var str = Encoding.UTF8.GetString(buffer, 0, effective);
                //Console.WriteLine(str);

                var deStr = CustomEncrypt.Decrypt(str);

                Console.WriteLine(deStr);
            }
        }
    }
}
