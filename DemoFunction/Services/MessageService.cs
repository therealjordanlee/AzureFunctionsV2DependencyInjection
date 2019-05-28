using DemoFunction.Repositories;
using Microsoft.Extensions.Logging;

namespace DemoFunction.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRespository;
        private ILogger _logger;

        public MessageService(IMessageRepository messageRepository, ILogger<MessageService> logger)
        {
            _messageRespository = messageRepository;
            _logger = logger;
        }

        public string GetHelloMessage()
        {
            var response = _messageRespository.GetHelloMessage();
            return response;
        }

        public string GetGoodbyeMessage()
        {
            var response = _messageRespository.GetGoodbyeMessage();
            return response;
        }
    }
}
