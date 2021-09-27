using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

//http/3
builder.WebHost.ConfigureKestrel((context, options) =>
  {
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
      // Use HTTP/3
      listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
      listenOptions.UseHttps();
    });
  });
var app = builder.Build();

app.MapGet("/", () => "Hello Developers C# 10!");

app.Run();
