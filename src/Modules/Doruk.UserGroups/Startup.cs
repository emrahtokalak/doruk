using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using OrchardCore.Users.Models;
using Doruk.UserGroups.Drivers;
using Doruk.UserGroups.Indexes;
using Doruk.UserGroups.Models;
using Doruk.UserGroups.Services;

namespace Doruk.UserGroups;

public sealed class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddIndexProvider<UserByUserGroupNameIndexProvider>();

        services.AddDataMigration<Migrations>();
        services.AddPermissionProvider<Permissions>();
        services.AddNavigationProvider<AdminMenu>();

        services.AddContentPart<UserGroupsListPart>()
            .UseDisplayDriver<UserGroupsListPartDisplayDriver>();

        services.AddScoped<IDisplayDriver<User>, UserGroupsDisplayDriver>();
        services.AddScoped<UserGroupDocument>();
        services.AddScoped<UserGroupsManager>();
    }
}

