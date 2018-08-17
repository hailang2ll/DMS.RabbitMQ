using DMS.RabbitMQ.Model;
using DMS.RabbitMQ.Service;
using System;

namespace DMS.RabbitMQ.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMqProxy = new RabbitMQService();

            var input = Input();

            while (input != "exit")
            {
                var log = new MessageModel
                {
                    CreateDateTime = DateTime.Now,
                    Msg = input
                };
                rabbitMqProxy.Publish(log);

                input = Input();
            }

            rabbitMqProxy.Dispose();
        }

        private static string Input()
        {
            Console.WriteLine("请输入信息：");
            var input = Console.ReadLine();
            return input;
        }
    }
}
