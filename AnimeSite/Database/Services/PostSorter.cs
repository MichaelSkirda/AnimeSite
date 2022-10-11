using System;
using System.Linq;
using AnimeSite.Enums;
using AnimeSite.Models;

namespace AnimeSite.Database.Services
{
    public static class PostSorter
    {
        public static IQueryable<Post> OrderByPosts(OrderBy orderBy, IQueryable<Post> posts)
        {
            switch (orderBy)
            {
                case OrderBy.Name:
                    return posts.OrderBy(p => p.Name);

                case OrderBy.NameDescending:
                    return posts.OrderByDescending(p => p.Name);

                case OrderBy.Rating:
                    return posts.OrderBy(p => p.Rating);

                case OrderBy.RatingDescending:
                    return posts.OrderByDescending(p => p.Rating);

                case OrderBy.Time:
                    return posts.OrderBy(p => p.ReleaseYear);

                case OrderBy.TimeDescending:
                    return posts.OrderByDescending(p => p.ReleaseYear);

                case OrderBy.Views:
                    return posts.OrderBy(p => p.ViewsCount);

                case OrderBy.ViewsDescending:
                    return posts.OrderByDescending(p => p.ViewsCount);

                default:
                    throw new AnimeSite.Exceptions.InvalidTypeException(orderBy.ToString());
            }

        }
    }
}
