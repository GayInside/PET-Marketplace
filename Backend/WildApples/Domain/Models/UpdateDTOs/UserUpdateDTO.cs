using Domain.Entities;

namespace Domain.Models.UpdateDTOs
{
    public record UserUpdateDTO
    {
        public required long Id { get; init; }
        public bool IsDisabled { get; init; }
        public string Username { get; init; } = null!;
        public string PasswordHash { get; init; } = null!;
        public string Firstname { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public List<Publication>? Publications { get; init; }
        public List<Publication>? Favorites { get; init; }
        public Role UserRole { get; init; } = null!;
    }
}
