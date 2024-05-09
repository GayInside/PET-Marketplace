namespace Domain.Entities
{
    public class Subcategory : BaseEntity
    {
        public string Title { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;

        public virtual List<Publication>? Publications { get; set; }
    }
}
