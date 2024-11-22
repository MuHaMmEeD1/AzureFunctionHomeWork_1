using AzureFunctionHomeWork_1.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionHomeWork_1
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ISMTPService _sMTPService;

        public Function1(ILogger<Function1> logger, ISMTPService sMTPService)
        {
            _logger = logger;
            _sMTPService = sMTPService;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string email = req.Query["email"];

            //_logger.LogInformation("C# HTTP trigger function processed a request.");
            //return new OkObjectResult("Welcome to Azure Functions!");

            _sMTPService.SendSMTP(email, "Salam User");

            return new OkObjectResult("200 ok");
        }

      
    }
}
