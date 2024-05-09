using Domain.Entities;
using Domain.Utils;

namespace Domain.Models.UpdateDTOs
{
    public record RoleUpdateDTO
    {
        public required long Id { get; init; }
        public bool IsDisabled { get; init; }  
        public string Name { get; set; } = RolesScheme.DEFAULT_USER_ROLE;
        public List<User>? UsersWithRole { get; set; }
    }
}
