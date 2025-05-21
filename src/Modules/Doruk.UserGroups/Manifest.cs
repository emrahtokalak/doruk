using OrchardCore.Modules.Manifest;
using ManifestConstants = Doruk.Modules.Manifest.ManifestConstants;

[assembly: Module(
    Name = "User Groups",
    Author = ManifestConstants.Author,
    Website = ManifestConstants.Website,
    Version = "1.0.0",
    Description = "Provides a way to organize the users into group(s).",
    Category = "Security"
)]
