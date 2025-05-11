using OrchardCore.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOrchardCms();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(logger);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseOrchardCore(c => c.UseSerilogTenantNameLogging()).UsePoweredByOrchardCore(false);

app.Run();