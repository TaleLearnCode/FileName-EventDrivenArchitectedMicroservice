namespace SLS.Common.Services.Extensions;

public static class PagingExtensions
{

	public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int pageIndex, int pageSize)
		=> source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

	public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int pageIndex, int pageSize)
		=> source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

	public static int PageCount<TSource>(this IQueryable<TSource> source, int pageSize)
		=> (source.Count() + pageSize - 1) / pageSize;

	public static int PageCount<TSource>(this IEnumerable<TSource> source, int pageSize)
	{
		if (pageSize > 0 && source.Any())
			return (source.Count() + pageSize - 1) / pageSize;
		else if (source.Any())
			return 1;
		else
			return 0;
	}


}