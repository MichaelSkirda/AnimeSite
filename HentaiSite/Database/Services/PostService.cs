using System;
using System.Collections.Generic;
using System.Linq;
using HentaiSite.Models;
using HentaiSite.Models.ViewModels;

namespace HentaiSite.Database.Services
{
    public class PostService
    {

        private readonly ApplicationContext db;
        private readonly TagService tagService;

        private const int SimilarAnimeCount = 6;

        public PostService(ApplicationContext db, TagService tagService)
        {
            this.db = db;
            this.tagService = tagService;
        }

        public void CreatePost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void SetTagsToPosts(Post post)
        {


            var tags = db.Tags.Join(db.TagEntities.Where(p => p.PostID == post.ID),
                t => t.ID,
                e => e.TagID,
                (t, e) => new Tag
                {
                    ID = t.ID,
                    Name = t.Name,
                    Description = t.Description
                }).ToList();

            post.Tags = tags;
        }

        public void SetTagsToPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            {
                SetTagsToPosts(post);
            }
        }


        public void SetStudiosToPosts(Post post)
        {

            List<Studio> studios = db.Studios.Join(db.StudioEntities.Where(s => s.PostID == post.ID),
                studio => studio.ID,
                entity => entity.StudioID,
                (studio, entity) => new Studio
                {
                    ID = studio.ID,
                    Name = studio.Name,
                    Description = studio.Description
                }).ToList();

            post.Studios = studios;
        }

        /// <summary>
        /// Return {count} anime with same tags
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Post> GetSimilarAnime(Post post, int count = SimilarAnimeCount)
        {

            // Step 1. Take Tag Entities WHERE Tag ID EQUALS one of post Tag ID 

            List<TagEntity> postTagsEntities = db.TagEntities
                .Where(t => t.PostID == post.ID).ToList();

            //List<Post> similarPosts = db.TagEntities.Where(t => postTagsEntities.E)


            throw new NotImplementedException();
        }

        public void SetStudiosToPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            {
                SetStudiosToPosts(post);
            }
        }


        public void SetDirectorsToPosts(Post post)
        {

            List<Director> directors = db.Directors.Join(db.DirectorEntities.Where(d => d.PostID == post.ID),
                director => director.ID,
                entity => entity.DirectorID,
                (director, entity) => new Director
                {
                    ID = director.ID,
                    Name = director.Name,
                    Description = director.Description
                }).ToList();

            post.Directors = directors;
        }

        public void SetDirectorsToPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            {
                SetDirectorsToPosts(post);
            }
        }


        public void SetMetadataToPosts(Post post)
        {
            SetTagsToPosts(post);
            SetStudiosToPosts(post);
            SetDirectorsToPosts(post);
        }

        public void SetMetadataToPosts(List<Post> posts)
        {
            foreach(Post post in posts)
            {
                SetMetadataToPosts(post);
            }
        }


        public List<Post> GetTopHundredByRating()
        {
            List<Post> posts = db.Posts.OrderByDescending(p => p.Rating).Take(100).ToList();
            return posts;
        }

        public List<Post> GetTopHundredByViews()
        {
            List<Post> posts = db.Posts.OrderByDescending(p => p.ViewsCount).Take(100).ToList();
            return posts;
        }


        public Post GetRandomPost()
        {
            Random random = new Random();
            Post post = db.Posts.First(p => p.ID == random.Next(1, db.Posts.Count() + 1));
            return post;
        }

        public Post GetPostByID(int ID)
        {
            Post post = db.Posts.First(p => p.ID == ID);
            return post;
        }

        /// <summary>
        /// Search posts by paremeters. Return IQueryable, not IEnumerable
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="year"></param>
        /// <param name="tagID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IQueryable<Post> GetPostsIQueryable(string orderBy, int? year = null, int? tagID = null)
        {
            

            IQueryable<Post> posts;

            if (year != null)
            {
                posts = db.Posts.Where(p => p.ReleaseYear == year);
            }
            else
            {
                posts = db.Posts;
            }

            if (tagID != null)
            {
                try
                {
                    Tag tag = tagService.GetTagByID(tagID ?? throw new NullReferenceException());

                    posts = db.TagEntities.Where(t => t.TagID == tag.ID).Join(posts,
                        t => t.PostID,
                        p => p.ID,
                        (t, p) => p
                        );
                }
                catch
                {

                }
            }


            switch (orderBy)
            {
                case "name":
                    posts = posts.OrderByDescending(p => p.Name);
                    break;
                case "name-d":
                    posts = posts.OrderBy(p => p.Name);
                    break;
                case "rating":
                    posts = posts.OrderBy(p => p.Rating);
                    break;
                case "rating-d":
                    posts = posts.OrderByDescending(p => p.Rating);
                    break;
                case "time":
                    posts = posts.OrderBy(p => p.ReleaseYear);
                    break;
                case "time-d":
                    posts = posts.OrderByDescending(p => p.ReleaseYear);
                    break;
                case "views":
                    posts = posts.OrderBy(p => p.ViewsCount);
                    break;
                case "views-d":
                    posts = posts.OrderByDescending(p => p.ViewsCount);
                    break;
                default:
                    posts = posts.OrderByDescending(p => p.Rating);
                    break;
            }

            return posts;

        }

        public List<Post> GetPosts(string orderBy, int Count, int page, int? year = null, int? tagID = null)
        {
            if (page <= 0)
            {
                throw new InvalidOperationException("Page number is negotiv");
            }

            List<Post> posts = GetPostsIQueryable(orderBy, year, tagID).Skip((page - 1) * Count).ToList();

            return posts;
        }

        

        


    }
}
