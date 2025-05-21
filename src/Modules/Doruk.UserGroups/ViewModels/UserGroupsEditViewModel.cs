using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Doruk.UserGroups.ViewModels;

public class UserGroupsEditViewModel
{
    [BindNever]
    public IEnumerable<string> UserGroups { get; set; }

    public string[] SelectedUserGroups { get; set; }
}
