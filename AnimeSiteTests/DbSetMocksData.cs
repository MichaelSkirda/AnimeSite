using System;
using System.Collections.Generic;
using System.Linq;
using HentaiSite.Models;
using HentaiSite.Enums;

namespace HentaiSiteTests
{
    public class DbSetMocksData
    {

        public static List<Post> GetPostsMockData()
        {
            var posts = new List<Post>()
                {
                    new Post()
                    {
                        ID = 1,
                        Duration = 20,
                        Name = "Code Geass",
                        ImgFormat = "jpg",
                        ReleaseYear = 2006,
                        SeriesCount = 24,
                        Rating = 600,
                        ViewsCount = 13565,
                        Status = AnimeStatus.Released
                    },
                    new Post()
                    {
                        ID = 2,
                        Duration = 20,
                        Name = "Berserk",
                        ImgFormat = "jpg",
                        ReleaseYear = 1997,
                        Status = AnimeStatus.Released,
                        SeriesCount = 51,
                        Rating = 692,
                        ViewsCount = 11234,
                        OtherNamesString = string.Join(";#;", new string[] { "Reznya Blyat", "Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat " }),
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.\nLorem ipsum dolor sit amet consectetur adipisicing elit."
                    },
                    new Post()
                    {
                        ID = 3,
                        Duration = 20,
                        Name = "Steins;Gate",
                        ImgFormat = "jpg",
                        ReleaseYear = 2016,
                        SeriesCount = 36,
                        Rating = 542,
                        ViewsCount = 24512,
                        Status = AnimeStatus.Released,
                        Censured = true
                    },
                    new Post()
                    {
                        ID = 4,
                        Duration = 20,
                        Name = "Vinland Saga",
                        ImgFormat = "jpeg",
                        ReleaseYear = 2018,
                        SeriesCount = 30,
                        Rating = 220,
                        ViewsCount = 8231,
                        Status = AnimeStatus.Released
                    },
                    new Post()
                    {
                        ID = 5,
                        Duration = 20,
                        Name = "Vinland Saga (2016)",
                        ImgFormat = "jpeg",
                        ReleaseYear = 2016,
                        SeriesCount = 30,
                        Rating = 320,
                        ViewsCount = 8231,
                        Status = AnimeStatus.Released
                    },
                    new Post()
                    {
                        ID = 4,
                        Duration = 20,
                        Name = "Anime of 2016 year",
                        ImgFormat = "jpeg",
                        ReleaseYear = 2016,
                        SeriesCount = 30,
                        Rating = 220,
                        ViewsCount = 8231,
                        Status = AnimeStatus.Released
                    },
                };

            return posts;
        }

        public static List<Studio> GetStudios()
        {
            var studios = new List<Studio>()
                    {
                        new Studio()
                        {
                            ID = 1,
                            Name = "YuriStudio",
                            Description = "Best Yuri hentai video in 4KKK"
                        },
                        new Studio()
                        {
                            ID = 2,
                            Name = "RezNYA",
                            Description = "Most REZNYA BLYAT videos, very much BLOOD, KISHKI i UBIYSTVA"
                        },
                        new Studio()
                        {
                            ID = 3,
                            Name = "Regular hentai",
                            Description = "Nothing special"
                        },
                    };

            return studios;
        }

        public static List<StudioEntity> GetStudioEntities()
        {
            var studioEntityes = new List<StudioEntity>()
                    {
                        new StudioEntity()
                        {
                            ID = 1,
                            PostID = 1,
                            StudioID = 1,
                        },
                        new StudioEntity()
                        {
                            ID = 2,
                            PostID = 2,
                            StudioID = 2,
                        },
                        new StudioEntity()
                        {
                            ID = 3,
                            PostID = 3,
                            StudioID = 3,
                        },
                        new StudioEntity()
                        {
                            ID = 4,
                            PostID = 4,
                            StudioID = 2,
                        },
                        new StudioEntity()
                        {
                            ID = 5,
                            PostID = 4,
                            StudioID = 2,
                        },
                    };

            return studioEntityes;
        }


        public static List<Tag> GetTags()
        {

            var tags = new List<Tag>()
                {
                    new Tag()
                    {
                        ID = 1,
                        Name = "Юри"
                    },
                    new Tag()
                    {
                        ID = 2,
                        Name = "Детектив"
                    },
                    new Tag()
                    {
                        ID = 3,
                        Name = "Экшен"
                    },
                    new Tag()
                    {
                        ID = 4,
                        Name = "Глубокий сюжет"
                    },
                    new Tag()
                    {
                        ID = 5,
                        Name = "Резня"
                    },
                };

            return tags;

        }

        public static List<TagEntity> GetTagEntities()
        {

            var tagEntities = new List<TagEntity>()
                    {
                        new TagEntity()
                        {
                            ID = 1,
                            PostID = 1,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            ID = 2,
                            PostID = 1,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            ID = 3,
                            PostID = 1,
                            TagID = 3
                        },
                        new TagEntity()
                        {
                            ID = 4,
                            PostID = 2,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            ID = 5,
                            PostID = 2,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            ID = 6,
                            PostID = 3,
                            TagID = 4
                        },
                        new TagEntity()
                        {
                            ID = 7,
                            PostID = 3,
                            TagID = 1
                        },
                        new TagEntity()
                        {
                            ID = 8,
                            PostID = 4,
                            TagID = 5
                        },
                        new TagEntity()
                        {
                            ID = 9,
                            PostID = 4,
                            TagID = 4
                        },
                    };

            return tagEntities;

        }

        public static List<Director> GetDirectors()
        {
            var directors = new List<Director>()
                    {
                        new Director()
                        {
                            ID = 1,
                            Name = "Hentai director 1",
                            Description = "123"
                        },
                        new Director()
                        {
                            ID = 2,
                            Name = "Hentai director 2",
                            Description = "AAAAAAAAAAAH"
                        },
                        new Director()
                        {
                            ID = 3,
                            Name = "Name Surname",
                            Description = "Some description"
                        },
                    };

            return directors;
        }

        public static List<DirectorEntity> GetDirectorEntities()
        {
            var directorEntities = new List<DirectorEntity>()
                    {
                        new DirectorEntity()
                        {
                            ID = 1,
                            DirectorID = 1,
                            PostID = 1,
                        },
                        new DirectorEntity()
                        {
                            ID = 2,
                            DirectorID = 2,
                            PostID = 2,
                        },
                        new DirectorEntity()
                        {
                            ID = 3,
                            DirectorID = 3,
                            PostID = 3,
                        },
                        new DirectorEntity()
                        {
                            ID = 4,
                            DirectorID = 1,
                            PostID = 4,
                        },
                    };

            return directorEntities;
        }

        public static List<UserView> GetUserViews()
        {
            var userViews = new List<UserView>()
            {
                new UserView()
                {
                    PostID = 1,
                    IPAddressBytes = new byte[] { 127, 0, 0 , 1 }
                }
            };

            return userViews;
        }

        public static List<Comment> GetComments()
        {
            var comments = new List<Comment>()
            {
                new Comment()
                {
                    ID = 1,
                    AuthorName = "Van",
                    Date = new DateTime(2021, 6, 2),
                    PostID = 1,
                    Text = "Hello, it's my comment"
                },
                new Comment()
                {
                    ID = 2,
                    AuthorName = "Billie",
                    Date = new DateTime(2022, 7, 5),
                    PostID = 1,
                    Text = "Some another text"
                },
                new Comment()
                {
                    ID = 3,
                    AuthorName = "Van",
                    Date = new DateTime(2020, 4, 20),
                    PostID = 2,
                    Text = "Comment to post with id 2"
                },
            };

            return comments;
        }

    }
}
