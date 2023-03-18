namespace SLS.Common.Services.Responses;

public class ListResponse<T>
{

	public int PageSize { get; set; }

	public int PageIndex { get; set; }

	public int PageCount { get; set; }

	public int TotalRecords { get; set; }

	public int RecordsReturned { get; set; }

	public IList<T>? Items { get; set; }

}
