using HentaiSite.Models.ViewModels;
using HentaiSite.Models;
using System.Linq;
using System;

namespace HentaiSite.Database.Services
{
    public class ViewModelService
    {
        private readonly ApplicationContext db;
        private readonly EntitiesService entitiesService;
        private readonly PostService postService;

        public ViewModelService(ApplicationContext db, EntitiesService entitiesService, PostService postService)
        {
            this.db = db;
            this.entitiesService = entitiesService;
            this.postService = postService;
        }

        public IndexViewModel GetIndexViewModel(int PageItemCount, string orderBy = "default", int page = 1, string s = "", int? year = null, int? tagID = null)
        {
            IQueryable<Post> posts = postService.GetPostsIQueryable(orderBy, year, tagID, s: s);
            int totalPageCount = (int)Math.Ceiling((float)posts.Count() / PageItemCount);
            IndexViewModel viewModel = new IndexViewModel()
            {
                posts = posts.Skip((page - 1) * PageItemCount).Take(PageItemCount).ToList(),
                totalPages = totalPageCount,
                page = page,
                mostPopularTags = entitiesService.GetMostPopularTags()
            };

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public PostViewModel GetPostViewModel(int postID)
        {
            PostViewModel postViewModel = new PostViewModel()
            {
                mostPopularTags = entitiesService.GetMostPopularTags(),
                post = postService.GetPostByID(postID),
            };

            //postViewModel.SimilarAnime = postService.GetSimilarAnime(postViewModel.post);

            postService.SetMetadataToPosts(postViewModel.post);

            return postViewModel;
        }

        public SearchOnePageViewModel GetOnePageTopHundredViewModel(string topBy)
        {
            SearchOnePageViewModel onePageViewModel = GetSearchOnePageViewModel();

            if(topBy == "views")
            {
                onePageViewModel.posts = postService.GetTopHundredByViews();
            }
            else
            {
                onePageViewModel.posts = postService.GetTopHundredByRating();
            }

            return onePageViewModel;
        }

        public Post GetRandomPostID()
        {
            return postService.GetRandomPost();
        }

        private SearchOnePageViewModel GetSearchOnePageViewModel()
        {
            return new SearchOnePageViewModel() { mostPopularTags = entitiesService.GetMostPopularTags() };
        }

        public PostViewModel GetPostViewModeRandom()
        {
            PostViewModel postViewModel = new PostViewModel()
            {
                mostPopularTags = entitiesService.GetMostPopularTags(),
                post = postService.GetRandomPost(),
            };

            //postViewModel.SimilarAnime = postService.GetSimilarAnime(postViewModel.post);

            postService.SetMetadataToPosts(postViewModel.post);

            return postViewModel;
        }

        private SearchOnePageViewModel GetSearchOnePageViewModel(SearchEntity searchEntity)
        {
            SearchOnePageViewModel indexViewModel = new SearchOnePageViewModel()
            {
                mostPopularTags = entitiesService.GetMostPopularTags(),
                HasPreview = searchEntity.HasPreview,
                PreviewThumbnailPath = searchEntity.ThumbnailPath,
                PreviewDescription = searchEntity.Description,
                PreviewName = searchEntity.Name,
            };
            return indexViewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageYearViewModel(int year, string orderby)
        {
            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel();
            viewModel.orderBy = orderby;

            viewModel.posts = postService.GetPostsByYear(year, orderby);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageStudioViewModel(int id, string orderby)
        {
            Studio studio = entitiesService.GetStudioByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(studio);
            viewModel.orderBy = orderby;

            viewModel.posts = postService.GetPostsByStudio(id, orderby);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        internal SearchOnePageViewModel GetOnePageAdminFavorite(string orderby)
        {
            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel();
            viewModel.orderBy = orderby;

            viewModel.posts = postService.GetAdminFavoritePosts(orderby);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageTagViewModel(int id, string orderby)
        {
            Tag tag = entitiesService.GetTagByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(tag);
            viewModel.orderBy = orderby;

            viewModel.posts = postService.GetPostsByTag(id, orderby);

            postService.SetMetadataToPosts(viewModel.posts);


            return viewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageDirectorViewModel(int id, string orderby)
        {
            Director director = entitiesService.GetDirectorByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(director);
            viewModel.orderBy = orderby;

            viewModel.posts = postService.GetPostsByDirector(id, orderby);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }


        public BasicViewModel GetBasicViewModel()
        {
            BasicViewModel basicViewModel = new BasicViewModel()
            {
                mostPopularTags = entitiesService.GetMostPopularTags(),
            };

            return basicViewModel;
        }

    }
}
