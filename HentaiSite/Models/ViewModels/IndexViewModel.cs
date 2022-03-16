﻿using HentaiSite.Database.Services;
using System;
using System.Collections.Generic;

namespace HentaiSite.Models.ViewModels
{
    public class IndexViewModel : BasicViewModel
    {
        public List<Post> posts;
        public List<Tag> Tags;
        public List<int> ActiveTags;
        public string queryString;
        public string queryStringWithoutPage;
        public string orderBy;
        public int page;
        public int totalPages;

        public IndexViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }

        public bool HasPreviousPage()
        {
            return page > 1;
        }

        public bool HasNextPage()
        {
            return page < totalPages;
        }
    }
}
