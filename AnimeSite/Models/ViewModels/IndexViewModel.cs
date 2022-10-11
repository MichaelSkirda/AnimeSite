using AnimeSite.Database.Services;
using System;
using System.Collections.Generic;

namespace AnimeSite.Models.ViewModels
{
    public class IndexViewModel : BasicViewModel
    {
        public List<Post> posts;
        public List<Tag> Tags;
        public List<int> ActiveTags;
        public string queryStringWithoutOrderBy;
        public string queryStringWithoutPage;
        public string orderBy;
        public int currentPage;
        public int totalPages;

        public IndexViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }

        public bool HasPreviousPage()
        {
            return currentPage > 1;
        }

        public bool HasNextPage()
        {
            return currentPage < totalPages;
        }
    }
}
