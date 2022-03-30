using System;
namespace HentaiSite.Enums
{
    public enum OrderBy
    {
        Name,
        NameDescending,
        Rating,
        RatingDescending,
        Time,
        TimeDescending,
        Views,
        ViewsDescending
    }

    public static class OrderByExntension
    {
        public static OrderBy StringToOrderBy(string value)
        {
            switch (value)
            {
                case "name":
                    return OrderBy.Name;
                case "name-d":
                    return OrderBy.NameDescending;
                case "rating":
                    return OrderBy.Rating;
                case "rating-d":
                    return OrderBy.RatingDescending;
                case "time":
                    return OrderBy.Time;
                case "time-d":
                    return OrderBy.TimeDescending;
                case "views":
                    return OrderBy.Views;
                case "views-d":
                    return OrderBy.ViewsDescending;
                default:
                    throw new ArgumentException($"{value} - ENUM doesn't exist");
            }
        }
    }
}
