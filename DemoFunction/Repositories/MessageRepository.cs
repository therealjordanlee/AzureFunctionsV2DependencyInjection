using DemoFunction.Configurations;

namespace DemoFunction.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageConfiguration _messageConfiguration;

        public MessageRepository(MessageConfiguration messageConfiguration)
        {
            _messageConfiguration = messageConfiguration;
        }

        public string GetHelloMessage()
        {
            return _messageConfiguration.HelloMessage;
        }

        public string GetGoodbyeMessage()
        {
            return _messageConfiguration.GoodbyeMessage;
        }
    }
}
