using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace Doruk.SystemMonitor;

/// <summary>
/// Represents an admin menu for System module.
/// </summary>
public class AdminMenu : AdminNavigationProvider
{
    private readonly IStringLocalizer _s;

    /// <summary>
    /// Initializes a new instance of <see cref="AdminMenu"/>.
    /// </summary>
    /// <param name="stringLocalizer">The <see cref="IStringLocalizer{AdminMenu}"/>.</param>
    public AdminMenu(IStringLocalizer<AdminMenu> stringLocalizer)
    {
        _s = stringLocalizer;
    }

    protected override ValueTask BuildAsync(NavigationBuilder builder)
    {
        builder.Add(_s["Configuration"], configuration => configuration
                        // .Add(_s["Settings"], settings => settings
                        .Add(_s["System Monitor"], _s["System Monitor"].PrefixPosition(), system => system
                            .AddClass("info").Id("info")
                            .Action("About", "Admin", "Unigate.SystemMonitor")
                            .LocalNav())
                    );

        return ValueTask.CompletedTask;
    }
}
