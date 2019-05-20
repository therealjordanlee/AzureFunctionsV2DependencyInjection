using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFunction.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly string _message;

        public MessageRepository(string message)
        {
            _message = message;
        }

        public string GetMessage()
        {
            return _message;
        }
    }
}
