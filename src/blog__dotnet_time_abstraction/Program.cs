using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton(TimeProvider.System);
services.AddSingleton<GreetingService>();

var serviceProvider = services.BuildServiceProvider();
var greetingService = serviceProvider.GetRequiredService<GreetingService>();
var greetingMessage = greetingService.GetGreetingMessage();
Console.WriteLine(greetingMessage);
