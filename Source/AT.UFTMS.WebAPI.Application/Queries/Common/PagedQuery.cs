namespace AT.UFTMS.WebAPI.Application.Queries.Common;
public abstract class PagedQuery
{
    public int Page { get; init; } = 1;

    public int PageSize { get; init; } = 10;

    public int Skip => (Page - 1) * PageSize;
}