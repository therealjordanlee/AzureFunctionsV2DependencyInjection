using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DemoFunction.Services;

namespace FunctionApp1
{
    public class Function1
    {
        private readonly IMessageService _messageService;
        private readonly ILogger _logger;

        public Function1(IMessageService messageService, ILogger<Function1> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "hello")] HttpRequest req)
        {
            var xxx = _messageService.GetHelloMessage();
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult("ok");
        }
    }
}
