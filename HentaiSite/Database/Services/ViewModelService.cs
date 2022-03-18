using HentaiSite.Models.ViewModels;
using HentaiSite.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace HentaiSite.Database.Services
{
    public class ViewModelService
    {
        private readonly ApplicationContext db;
        private readonly EntitiesService entitiesService;
        private readonly PostService postService;

        private readonly int IndexViewModelTagCount = 20;

        public ViewModelService(ApplicationContext db, EntitiesService entitiesService, PostService postService)
        {
            this.db = db;
            this.entitiesService = entitiesService;
            this.postService = postService;
        }

        public IndexViewModel GetIndexViewModel(int pageItemCount, string orderBy = "default", int page = 1, string s = "", int? year = null, List<int> tagIDs = null)
        {
            IQueryable<Post> posts = postService.GetPostsIQueryable(orderBy, year, tagIDs, s: s);
            int totalPageCount = GetPageCount(posts.Count(), pageItemCount);
            IndexViewModel viewModel = new IndexViewModel(postService, entitiesService)
            {
                posts = posts.Skip((page - 1) * pageItemCount).Take(pageItemCount).ToList(),
                totalPages = totalPageCount,
                currentPage = page,
                Tags = entitiesService.GetMostPopularTags(IndexViewModelTagCount),
            };

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public IndexViewModel GetNoCensureIndexViewModel(int pageItemCount, string orderby, int page = 1, List<int> tag = null)
        {
            // Get posts
            IQueryable<Post> postsQuery = postService.GetPostsWithoutCensure(orderby, tag);

            // Set metadata
            int totalPageCount = GetPageCount(postsQuery.Count(), pageItemCount);
            postsQuery = postService.GetPostsAtPage(page, pageItemCount, postsQuery);
            List<Post> posts = postsQuery.ToList();
            postService.SetMetadataToPosts(posts);

            // Create viewModel
            IndexViewModel indexNoCensureViewModel = new IndexViewModel(postService, entitiesService)
            {
                posts = posts,
                totalPages = totalPageCount,
                Tags = entitiesService.GetMostPopularTags(IndexViewModelTagCount)
            };

            return indexNoCensureViewModel;
        }

        internal YearsViewModel GetYearsViewModel()
        {
            YearsViewModel yearsViewModel = new YearsViewModel(postService, entitiesService)
            {
                FromYear = db.Posts.OrderBy(p => p.ReleaseYear).First().ReleaseYear,
                ToYear = db.Posts.OrderByDescending(p => p.ReleaseYear).First().ReleaseYear,
            };
            return yearsViewModel;
        }

        private int GetPageCount(int postsCount, int pageItemCount)
        {
            return (int)Math.Ceiling((float)postsCount / pageItemCount);
        }

        public PostViewModel GetPostViewModel(int postID)
        {
            PostViewModel postViewModel = new PostViewModel(postService, entitiesService)
            {
                post = postService.GetPostByID(postID),
            };

            postViewModel.Comments = postService.GetCommentsByPostID(postViewModel.post.ID);

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

            postService.SetMetadataToPosts(onePageViewModel.posts);

            return onePageViewModel;
        }

        

        public AllTagsViewModel GetAllTagsViewModel()
        {
            AllTagsViewModel allTagsViewModel = new AllTagsViewModel(postService, entitiesService)
            {
                Tags = db.Tags.OrderBy(t => t.Name).ToList()
            };
            return allTagsViewModel;
        }

        public Post GetRandomPostID()
        {
            return postService.GetRandomPost();
        }

        private SearchOnePageViewModel GetSearchOnePageViewModel()
        {
            return new SearchOnePageViewModel(postService, entitiesService);
        }

        public void AddView(IPAddress ipAddress, Post post)
        {
            // If this ipAddress already accounted at post

            byte[] ipAddressBytes = ipAddress.GetAddressBytes();

            UserView userView = db.UserViews.Where(v => v.PostID == post.ID && v.IPAddressBytes == ipAddressBytes).FirstOrDefault();

            if (userView != null)
                return;

            db.UserViews.Add(new UserView() { IPAddressBytes = ipAddressBytes, PostID = post.ID });
            post.ViewsCount++;
            db.SaveChanges();
        }

        public PostViewModel GetPostViewModeRandom()
        {
            PostViewModel postViewModel = new PostViewModel(postService, entitiesService)
            {
                post = postService.GetRandomPost(),
            };

            //postViewModel.SimilarAnime = postService.GetSimilarAnime(postViewModel.post);

            postService.SetMetadataToPosts(postViewModel.post);

            return postViewModel;
        }

        private SearchOnePageViewModel GetSearchOnePageViewModel(SearchEntity searchEntity)
        {
            SearchOnePageViewModel indexViewModel = new SearchOnePageViewModel(postService, entitiesService)
            {
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

        public object GetPostsJSONByTagsIDs(List<int> tagIDs)
        {
            var tagGroups = db.TagEntities
                .Where(t => tagIDs.Contains(t.TagID))
                .GroupBy(t => t.PostID)
                .Where(g => g.Count() >= tagIDs.Count());


            var posts = postService.GetPostsByIDs(tagGroups.Select(g => g.Key).ToList());

            postService.SetTagsToPosts(posts);

            var result = posts.Select(p => new
            {
                id = p.ID,
                name = p.Name,
                releaseYear = p.ReleaseYear,
                tags = p.Tags
                        .Select(t => new {
                            id = t.ID,
                            name = t.Name,
                        })
            });


            return result;
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
            BasicViewModel basicViewModel = new BasicViewModel(postService, entitiesService);

            return basicViewModel;
        }

    }
}
