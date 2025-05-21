using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "System",
    Author = DorukManifestConstants.Author,
    Website = DorukManifestConstants.Website,
    Category = "Utilities"
)]

[assembly: Feature(
    Id = "Doruk.SystemMonitor",
    Name = "System",
    Description = "Provides an information about currently running application.",
    DefaultTenantOnly = true
)]
