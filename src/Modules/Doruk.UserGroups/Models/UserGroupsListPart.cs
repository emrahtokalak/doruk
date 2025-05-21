using OrchardCore.ContentManagement;

namespace Doruk.UserGroups.Models;

public class UserGroupsListPart : ContentPart
{
    public string[] UserGroups { get; set; } = [];
}
