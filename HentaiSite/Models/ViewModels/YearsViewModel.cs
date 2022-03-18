﻿using HentaiSite.Database.Services;

namespace HentaiSite.Models.ViewModels
{
    public class YearsViewModel : BasicViewModel
    {
        public int FromYear { get; set; }
        public int ToYear { get; set; }

        public YearsViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }
    }
}
