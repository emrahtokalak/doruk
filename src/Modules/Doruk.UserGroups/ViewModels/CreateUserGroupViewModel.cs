using System.ComponentModel.DataAnnotations;

namespace Doruk.UserGroups.ViewModels;

public class CreateUserGroupViewModel
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
