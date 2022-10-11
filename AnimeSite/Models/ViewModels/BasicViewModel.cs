using AnimeSite.Database.Services;
using System.Collections.Generic;

namespace AnimeSite.Models.ViewModels
{
    public class BasicViewModel
    {
        public List<Tag> mostPopularTags;
        public Post mostPopularPostToday;
        public Post mostPopularPostThisWeek;
        public Post mostPopularPostEver;

        public BasicViewModel(PostService postService, EntitiesService entitiesService)
        {
            mostPopularTags = entitiesService.GetMostPopularTags();
            mostPopularPostToday = postService.GetMostPopularPostToday();
            mostPopularPostThisWeek = postService.GetMostPopularPostThisWeek();
            mostPopularPostEver = postService.GetMostPopularPostEver();
        }
    }
}
