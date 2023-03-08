namespace SLS.Common.Services.Extensions;

public static class StringExtensions
{

	public static Uri? ToUri(this string? uriString, UriKind uriKind = UriKind.Absolute)
	{
		Uri.TryCreate(uriString, uriKind, out Uri? result);
		return result;
	}

}