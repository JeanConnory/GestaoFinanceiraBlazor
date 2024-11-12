namespace Gestao.Domain.Libraries.Utilities;

public class PaginatedList<T>
{
    public PaginatedList(List<T> items, int pageIndex, int totalPages)
    {
        Items = items;
        PageIndex = pageIndex;
        TotalPages = totalPages;
    }

    public List<T> Items { get; } = new();

    public int PageIndex { get; }

    public int TotalPages { get; set; }

    public bool HasNextPage => PageIndex < TotalPages;
    public bool HasPreviousPage => PageIndex > 1;    
}
