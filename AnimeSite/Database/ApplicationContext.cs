using System;
using System.Collections.Generic;
using System.Linq;
using AnimeSite.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeSite.Database
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagEntity> TagEntities { get; set; }

        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<StudioEntity> StudioEntities { get; set; }

        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<DirectorEntity> DirectorEntities { get; set; }

        public virtual DbSet<UserView> UserViews { get; set; }
        public virtual DbSet<UserDownload> UserDownloads { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public ApplicationContext()
        {

        }


        /* Reznya Blyat;#;Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat  */
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           if(Database.EnsureCreated())
           {
                Posts.AddRange(new List<Post>()
                {
                    new Post()
                    {
                        Duration = 20,
                        Name = "Code Geass",
                        ImgFormat = "jpg",
                        ReleaseYear = 2006,
                        SeriesCount = 24,
                        Rating = 600,
                        ViewsCount = 13565,
                        Status = Enums.AnimeStatus.Released
                    },
                    new Post()
                    {
                        Duration = 20,
                        Name = "Berserk",
                        ImgFormat = "jpg",
                        ReleaseYear = 1997,
                        Status = Enums.AnimeStatus.Released,
                        SeriesCount = 51,
                        Rating = 692,
                        ViewsCount = 11234,
                        OtherNamesString = string.Join(";#;", new string[] { "Reznya Blyat", "Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat " }),
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.\nLorem ipsum dolor sit amet consectetur adipisicing elit."
                    },
                    new Post()
                    {
                        Duration = 20,
                        Name = "Steins;Gate",
                        ImgFormat = "jpg",
                        ReleaseYear = 2016,
                        SeriesCount = 36,
                        Rating = 542,
                        ViewsCount = 24512,
                        Status = Enums.AnimeStatus.Released,
                        Censured = true
                    },
                    new Post()
                    {
                        Duration = 20,
                        Name = "Vinland Saga",
                        ImgFormat = "jpeg",
                        ReleaseYear = 2018,
                        SeriesCount = 30,
                        Rating = 220,
                        ViewsCount = 8231,
                        Status = Enums.AnimeStatus.Released
                    },
                });

                Tags.AddRange(new List<Tag>()
                {
                    new Tag()
                    {
                        Name = "Юри"
                    },
                    new Tag()
                    {
                        Name = "Детектив"
                    },
                    new Tag()
                    {
                        Name = "Экшен"
                    },
                    new Tag()
                    {
                        Name = "Глубокий сюжет"
                    },
                    new Tag()
                    {
                        Name = "Резня"
                    },
                });

                TagEntities.AddRange(
                    
                    new List<TagEntity>()
                    {
                        new TagEntity()
                        {
                            PostID = 1,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            PostID = 1,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            PostID = 1,
                            TagID = 3
                        },
                        new TagEntity()
                        {
                            PostID = 2,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            PostID = 2,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            PostID = 3,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            PostID = 3,
                            TagID = 1
                        },
                        new TagEntity()
                        {
                            PostID = 4,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            PostID = 4,
                            TagID = 4
                        },
                    });

                Studios.AddRange(
                    
                    new List<Studio>()
                    {
                        new Studio()
                        {
                            Name = "YuriStudio",
                            Description = "Best Yuri hentai video in 4KKK"
                        },
                        new Studio()
                        {
                            Name = "RezNYA",
                            Description = "Most REZNYA BLYAT videos, very much BLOOD, KISHKI i UBIYSTVA"
                        },
                        new Studio()
                        {
                            Name = "Regular hentai",
                            Description = "Nothing special"
                        },
                    });


                StudioEntities.AddRange(

                    new List<StudioEntity>()
                    {
                        new StudioEntity()
                        {
                            PostID = 1,
                            StudioID = 1,
                        },
                        new StudioEntity()
                        {
                            PostID = 2,
                            StudioID = 2,
                        },
                        new StudioEntity()
                        {
                            PostID = 3,
                            StudioID = 3,
                        },
                        new StudioEntity()
                        {
                            PostID = 4,
                            StudioID = 2,
                        },
                        new StudioEntity()
                        {
                            PostID = 4,
                            StudioID = 2,
                        },
                    });

                Directors.AddRange(
                    
                    new List<Director>()
                    {
                        new Director()
                        {
                            Name = "Hentai director 1",
                            Description = "123"
                        },
                        new Director()
                        {
                            Name = "Hentai director 2",
                            Description = "AAAAAAAAAAAH"
                        },
                        new Director()
                        {
                            Name = "Name Surname",
                            Description = "Some description"
                        },
                    });


                DirectorEntities.AddRange(
                    
                    new List<DirectorEntity>()
                    {
                        new DirectorEntity()
                        {
                            DirectorID = 1,
                            PostID = 1,
                        },
                        new DirectorEntity()
                        {
                            DirectorID = 2,
                            PostID = 2,
                        },
                        new DirectorEntity()
                        {
                            DirectorID = 3,
                            PostID = 3,
                        },
                        new DirectorEntity()
                        {
                            DirectorID = 1,
                            PostID = 4,
                        },
                    });

                SaveChanges();

           }
        }

 
        



    }
}
