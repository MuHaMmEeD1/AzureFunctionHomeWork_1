using AzureFunctionHomeWork_1.Services.Abstracts;
using AzureFunctionHomeWork_1.Services.Concretes;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddScoped<ISMTPService, SMTPService>();

builder.Build().Run();
