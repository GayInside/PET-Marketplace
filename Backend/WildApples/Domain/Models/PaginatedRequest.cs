using MediatR;

namespace Domain.Models
{
    public abstract record PaginatedRequest<T> : IRequest<T>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
