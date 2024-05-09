namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = null!;

        public virtual List<Subcategory> Subcategories { get; set; } = null!;
    }
}
