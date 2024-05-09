using Domain.Utils;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = RolesScheme.DEFAULT_USER_ROLE;

        public virtual List<User>? UsersWithRole { get; set; }
    }
}
