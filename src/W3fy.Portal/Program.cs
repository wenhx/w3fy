var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureWebHostDefaults(webBuilder => 
{ 
    webBuilder.UseStartup<W3fy.Portal.Startup>();
});
var app = builder.Build();
app.Run();