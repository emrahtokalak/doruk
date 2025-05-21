using YesSql.Indexes;

namespace Doruk.UserGroups.Indexes;

public class UserByGroupNameIndex : ReduceIndex
{
    public string GroupName { get; set; }

    public int Count { get; set; }
}
