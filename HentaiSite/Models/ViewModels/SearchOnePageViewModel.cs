using HentaiSite.Database.Services;
using System.Collections.Generic;

namespace HentaiSite.Models.ViewModels
{
    public class SearchOnePageViewModel : BasicViewModel
    {
        public List<Post> posts;

        public bool HasPreview;

        public string PreviewName;
        public string PreviewDescription;
        public string PreviewThumbnailPath;

        public string orderBy;

        public SearchOnePageViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }
    }
}
