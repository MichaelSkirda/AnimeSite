using HentaiSite.Database.Services;
using System.Collections.Generic;

namespace HentaiSite.Models.ViewModels
{
    public class PostViewModel : BasicViewModel
    {
        public Post post;
        public List<Post> SimilarAnime;
        public List<Comment> Comments;

        public PostViewModel(PostService postService, EntitiesService entitiesService) : base(postService, entitiesService)
        {
        }
    }
}
