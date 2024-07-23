using System.Text.Json.Serialization;

namespace SomoSSolar.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{
    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount, int currentPage = 1, int pageSize = Configuration.DefaultPageSize) : base (data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public PagedResponse(TData data, int code = 200, string message = null) : base(data, code, message)
    {
       
    }

    public int CurrentPage { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);

}
