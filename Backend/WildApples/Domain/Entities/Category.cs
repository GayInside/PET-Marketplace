namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = null!;

        public virtual IEnumerable<Subcategory> Subcategories { get; set; } = null!;
    }
}
