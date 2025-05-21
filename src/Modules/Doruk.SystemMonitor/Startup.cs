using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using Doruk.SystemMonitor.Controllers;
using Doruk.SystemMonitor.Services;

namespace Doruk.SystemMonitor;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<INavigationProvider, AdminMenu>();

        services.AddSingleton<SystemInformation>();
    }

    public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
    {
        routes.MapAreaControllerRoute(
            name: "SystemInfo",
            areaName: "Doruk.SystemMonitor",
            pattern: "Admin/About",
            defaults: new { controller = typeof(AdminController).ControllerName(), action = nameof(AdminController.About) }
        );
    }
}