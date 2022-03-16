using HentaiSite.Database.Services;
using System.Collections.Generic;

namespace HentaiSite.Models.ViewModels
{
    public class AllTagsViewModel : BasicViewModel
    {

        public List<Tag> Tags;
        public AllTagsViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }
    }
}
