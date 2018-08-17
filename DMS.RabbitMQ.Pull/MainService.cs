using DMS.BaseFramework.Common.Serializer;
using DMS.RabbitMQ.Model;
using DMS.RabbitMQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.RabbitMQ.Pull
{
   public class MainService
    {
        private readonly RabbitMQService _rabbitMqProxy;
        public MainService()
        {
            _rabbitMqProxy = new RabbitMQService();
        }

        public bool Start()
        {
            var input = Input();
            while (input.ToLower() != "n")
            {
                _rabbitMqProxy.Pull<MessageModel>(msg =>
                {
                    Console.WriteLine(SerializerJson.SerializeObject(msg));
                });

                input = Input();
            }

            return true;
        }


        public bool Stop()
        {
            _rabbitMqProxy.Dispose();
            return true;
        }

        private static string Input()
        {
            Console.WriteLine("是否从队列取一条数据：Y/N");
            var input = Console.ReadLine();
            return input;
        }
    }
}
