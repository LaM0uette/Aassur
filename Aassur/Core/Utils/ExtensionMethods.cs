using System.Globalization;

namespace Aassur.Core.Utils;

public static class ExtensionMethods
{
    #region Date

    public static string ToDateString(this DateTime date)
    {
        return date.ToString(CultureInfo.InvariantCulture);
    }
    
    public static DateTime ToDateTime(this string date, string format = "yyyy-MM-dd")
    {
        if (string.IsNullOrEmpty(date)) return DateTime.Now;

        return DateTime.TryParseExact(
            date, 
            format, 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.None, 
            out var parsedDate
        ) ? parsedDate : DateTime.Now;
    }

    #endregion
}