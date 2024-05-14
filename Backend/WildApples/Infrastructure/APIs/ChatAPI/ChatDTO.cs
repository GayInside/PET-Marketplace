namespace Infrastructure.APIs.ChatAPI
{
    public record ChatDTO
    {
        public long FirstUserId { get; init; }

        public long SecondUserId { get; init; }
    }
}
