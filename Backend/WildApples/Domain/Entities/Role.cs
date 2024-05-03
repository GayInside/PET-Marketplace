using Domain.Utils;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = RolesScheme.DEFAULT_USER_ROLE;

        public virtual IEnumerable<User>? UsersWithRole { get; set; }
    }
}
