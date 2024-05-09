namespace Domain.Models.PaginationParams
{
    public abstract record BasePaginationParams
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
