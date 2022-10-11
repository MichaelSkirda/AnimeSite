using System;
namespace AnimeSite.Enums
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

    public static class OrderByExtension
    {
        public static OrderBy StringToOrderBy(string value, bool useOrderByNameAsDefault = true)
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
                    {
                        if (useOrderByNameAsDefault)
                        {
                            return OrderBy.Name;
                        }
                        else
                        {
                            throw new ArgumentException($"{value} - ENUM doesn't exist");

                        }
                    }
            }
        }
    }
}
