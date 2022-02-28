using HentaiSite.Models.ViewModels;
using HentaiSite.Models;
using System.Linq;
using System;

namespace HentaiSite.Database.Services
{
    public class ViewModelService
    {
        private readonly ApplicationContext db;
        private readonly TagService tagService;
        private readonly PostService postService;

        public ViewModelService(ApplicationContext db, TagService tagService, PostService postService)
        {
            this.db = db;
            this.tagService = tagService;
            this.postService = postService;
        }

        public IndexViewModel GetIndexViewModel(int PageItemCount, string orderBy = "default", int page = 1, int? year = null, int? tagID = null)
        {
            IQueryable<Post> posts = postService.GetPostsIQueryable(orderBy, year, tagID);
            int totalPageCount = (int)Math.Ceiling((float)posts.Count() / PageItemCount);
            IndexViewModel viewModel = new Models.ViewModels.IndexViewModel()
            {
                posts = posts.Skip((page - 1) * PageItemCount).Take(PageItemCount).ToList(),
                totalPages = totalPageCount,
                page = page,
                mostPopularTags = tagService.GetMostPopularTags()
            };

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public PostViewModel GetPostViewModel(int postID)
        {
            PostViewModel postViewModel = new PostViewModel()
            {
                mostPopularTags = tagService.GetMostPopularTags(),
                post = postService.GetPostByID(postID),
            };

            //postViewModel.SimilarAnime = postService.GetSimilarAnime(postViewModel.post);

            postService.SetMetadataToPosts(postViewModel.post);

            return postViewModel;
        }

        public PostViewModel GetPostViewModeRandom()
        {
            PostViewModel postViewModel = new PostViewModel()
            {
                mostPopularTags = tagService.GetMostPopularTags(),
                post = postService.GetRandomPost(),
            };

            //postViewModel.SimilarAnime = postService.GetSimilarAnime(postViewModel.post);

            postService.SetMetadataToPosts(postViewModel.post);

            return postViewModel;
        }

        public BasicViewModel GetBasicViewModel()
        {
            BasicViewModel basicViewModel = new BasicViewModel()
            {
                mostPopularTags = tagService.GetMostPopularTags(),
            };

            return basicViewModel;
        }

    }
}
