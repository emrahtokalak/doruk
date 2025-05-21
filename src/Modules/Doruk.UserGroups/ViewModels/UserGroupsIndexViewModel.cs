using Doruk.UserGroups.Models;

namespace Doruk.UserGroups.ViewModels;

public class UserGroupsIndexViewModel
{
    public IEnumerable<UserGroup> UserGroups { get; set; } = [];

    public string Search { get; set; }

    public dynamic Pager { get; set; }
}
