using DemoFunction.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFunction.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRespository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRespository = messageRepository;
        }

        public string GetMessage()
        {
            var response = _messageRespository.GetMessage();
            return response;
        }
    }
}
