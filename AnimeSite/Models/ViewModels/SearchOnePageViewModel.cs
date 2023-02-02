using AnimeSite.Database.Services;
using System.Collections.Generic;

namespace AnimeSite.Models.ViewModels
{
    public class SearchOnePageViewModel : BasicViewModel
    {
        public List<Post> posts;

        public bool HasPreview;

        public string PreviewName;
        public string PreviewDescription;
        public string PreviewThumbnailPath;

        public string orderBy;
        public string Title;

        public SearchOnePageViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }
    }
}
