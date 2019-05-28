using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DemoFunction.Services;

namespace FunctionApp1
{
    public class DemoFunction
    {
        private readonly IMessageService _messageService;
        private readonly ILogger _logger;

        public DemoFunction(IMessageService messageService, ILogger<DemoFunction> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        [FunctionName("HelloFunction")]
        public async Task<IActionResult> RunHello(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "hello")] HttpRequest req)
        {
            _logger.LogInformation("Processing Hello request");
            var msg = _messageService.GetHelloMessage();
            return new OkObjectResult(msg);
        }

        [FunctionName("GoodbyeFunction")]
        public async Task<IActionResult> RunGoodbye(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "goodbye")] HttpRequest req)
        {
            _logger.LogInformation("Processing Goodbye Request");
            var msg = _messageService.GetGoodbyeMessage();
            return new OkObjectResult(msg);
        }
    }
}
