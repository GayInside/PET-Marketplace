using Domain.Entities;

namespace Domain.Models
{
    public record AccountModel
    {
        public long Id { get; init; }

        public string Username { get; init; } = null!;

        public Role Role { get; init; } = null!;
    }
}
