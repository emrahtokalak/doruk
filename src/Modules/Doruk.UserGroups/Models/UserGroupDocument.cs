using OrchardCore.Data.Documents;

namespace Doruk.UserGroups.Models;

public class UserGroupDocument : Document
{
    public Dictionary<string, UserGroup> UserGroups { get; init; } = new(StringComparer.OrdinalIgnoreCase);
}
