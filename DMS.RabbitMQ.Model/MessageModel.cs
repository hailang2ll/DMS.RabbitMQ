using DMS.RabbitMQ.Service;
using System;

namespace DMS.RabbitMQ.Model
{
    [RabbitMQ("Test.QueueName", ExchangeName = "Test.ExchangeName", IsProperties = true)]
    public class MessageModel
    {
        public string Msg { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
