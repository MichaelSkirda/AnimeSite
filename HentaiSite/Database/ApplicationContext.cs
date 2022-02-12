using System;
using System.Collections.Generic;
using HentaiSite.Models;

namespace HentaiSite.Database
{
    public class ApplicationContext
    {
        public List<Post> Posts = new List<Post>()
        {
            new Post()
            {
                ID = 1,
                Duration = 20,
                Name = "Code Geass",
                Format = "jpg",
                ReleaseYear = 2006,
                SeriesCount = 24,
                Rating = 600,
                ViewsCount = 13565,
                Status = Enums.AnimeStatus.Released
            },
            new Post()
            {
                ID = 2,
                Duration = 20,
                Name = "Berserk",
                Format = "jpg",
                ReleaseYear = 1997,
                Status = Enums.AnimeStatus.Released,
                SeriesCount = 51,
                Rating = 692,
                ViewsCount = 11234,
                OtherNames = new string[] { "Reznya Blyat", "Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat Ubivat " },
                Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.\nLorem ipsum dolor sit amet consectetur adipisicing elit."
            },
            new Post()
            {
                ID = 3,
                Duration = 20,
                Name = "Steins;Gate",
                Format = "jpg",
                ReleaseYear = 2016,
                SeriesCount = 36,
                Rating = 542,
                ViewsCount = 24512,
                Status = Enums.AnimeStatus.Released,
                Censured = true
            },
            new Post()
            {
                ID = 4,
                Duration = 20,
                Name = "Vinland Saga",
                Format = "jpeg",
                ReleaseYear = 2018,
                SeriesCount = 30,
                Rating = 220,
                ViewsCount = 8231,
                Status = Enums.AnimeStatus.Released
            },
        };


        public List<Tag> Tags = new List<Tag>()
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


        public List<TagEntity> tagEntities = new List<TagEntity>()
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


        public List<Studio> Studios = new List<Studio>()
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

        public List<StudioEntity> StudioEntities = new List<StudioEntity>()
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

        public List<Director> Directors = new List<Director>()
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

        public List<DirectorEntity> DirectorEntities = new List<DirectorEntity>()
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

    }
}
