using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HentaiSite.Enums;

namespace HentaiSite.Models
{
    public class Post
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ViewsCount { get; set; }

        public int Rating { get; set; }

        public string ImgFormat { get; set; }

        public bool Censured { get; set; }

        public int ScreenCount { get; set; }


        public string[] OtherNames { get; set; }

        public AnimeStatus Status { get; set; }

        public int Duration { get; set; }

        public int ReleaseYear { get; set; }

        public int? EndingYear { get; set; }

        public int SeriesCount { get; set; }

        public bool IsVisible { get; set; }


        [NotMapped]
        public string ImgName
        {
            get
            {
                return ID + "." + ImgFormat;
            }
            private set { }
        }

        [NotMapped]
        public List<Tag> Tags { get; set; }

        [NotMapped]
        public List<Director> Directors { get; set; }

        [NotMapped]
        public List<Studio> Studios { get; set; }

    }
}
