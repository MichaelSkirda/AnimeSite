using System;
using System.Collections.Generic;
using System.Linq;
using HentaiSite.Models;
namespace HentaiSite.Database.Services
{
    public class PostService
    {

        private readonly ApplicationContext db;

        public PostService(ApplicationContext db)
        {
            this.db = db;
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

        public List<Post> GetPosts(string orderBy, int Count)
        {
            List<Post> posts;
            switch(orderBy)
            {
                case "name": // Yeah, I'm know it's incorrect
                    posts = db.Posts.OrderByDescending(p => p.Name).Take(Count).ToList();
                    break;
                case "name-d":
                    posts = db.Posts.OrderBy(p => p.Name).Take(Count).ToList();
                    break;
                case "rating":
                    posts = db.Posts.OrderBy(p => p.Rating).Take(Count).ToList();
                    break;
                case "rating-d":
                    posts = db.Posts.OrderByDescending(p => p.Rating).Take(Count).ToList();
                    break;
                case "time":
                    posts = db.Posts.OrderBy(p => p.ReleaseYear).Take(Count).ToList();
                    break;
                case "time-d":
                    posts = db.Posts.OrderByDescending(p => p.ReleaseYear).Take(Count).ToList();
                    break;
                case "views":
                    posts = db.Posts.OrderBy(p => p.ViewsCount).Take(Count).ToList();
                    break;
                case "views-d":
                    posts = db.Posts.OrderByDescending(p => p.ViewsCount).Take(Count).ToList();

                    break;
                default:
                    posts = db.Posts.Take(Count).ToList();
                    break;
            }
            return posts;
        }



    }
}
