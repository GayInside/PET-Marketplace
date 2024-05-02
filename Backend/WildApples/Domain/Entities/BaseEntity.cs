namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
