using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Shell;
using Doruk.SystemMonitor.Services;
using Doruk.SystemMonitor.ViewModels;

namespace Doruk.SystemMonitor.Controllers;

public class AdminController : Controller
{
    private readonly SystemInformation _systemInformation;
    private readonly IShellHost _shellHost;
    private readonly IShellFeaturesManager _shellFeaturesManager;

    public AdminController(
        SystemInformation systemInformation,
        IShellHost shellHost,
        IShellFeaturesManager shellFeaturesManager)
    {
        _systemInformation = systemInformation;
        _shellHost = shellHost;
        _shellFeaturesManager = shellFeaturesManager;
    }

    public async Task<ActionResult> About() => View(new AboutViewModel
    {
        SystemInformation = _systemInformation,
        Tenants = _shellHost.GetAllSettings(),
        Features = await _shellFeaturesManager.GetEnabledFeaturesAsync()
    });
}
