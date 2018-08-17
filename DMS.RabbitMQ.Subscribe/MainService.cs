using DMS.BaseFramework.Common.Serializer;
using DMS.RabbitMQ.Model;
using DMS.RabbitMQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.RabbitMQ.Subscribe
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
            _rabbitMqProxy.Subscribe<MessageModel>(msg =>
            {
                var json = SerializerJson.SerializeObject(msg);
                Console.WriteLine(json);
            });

            return true;
        }

        public bool Stop()
        {
            _rabbitMqProxy.Dispose();
            return true;
        }
    }
}
