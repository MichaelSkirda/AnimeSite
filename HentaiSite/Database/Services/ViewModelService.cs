using HentaiSite.Models.ViewModels;
using HentaiSite.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using HentaiSite.Enums;

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

        public IndexViewModel GetIndexViewModel(QueryData queryData)
        {
            IQueryable<Post> posts = postService.GetPostsIQueryable(queryData.orderBy, queryData.ReleaseYear, queryData.TagIDs, s: queryData.s);

            IndexViewModel viewModel = GetIndexViewModel(posts, queryData);


            return viewModel;
        }

        private IndexViewModel GetIndexViewModel(IQueryable<Post> postsQuery, QueryData queryData)
        {
            int totalPageCount = GetPageCount(postsQuery.Count(), queryData.PostsPerPage);
            List<Post> posts = postService.PostsOnPage(queryData.Page, queryData.PostsPerPage, postsQuery);
            List<Tag> tags = entitiesService.GetMostPopularTags(IndexViewModelTagCount);

            IndexViewModel viewModel = new IndexViewModel(postService, entitiesService)
            {
                posts = posts,
                totalPages = totalPageCount,
                currentPage = queryData.Page,
                Tags = tags,
                ActiveTags = queryData.TagIDs,
                orderBy = queryData.orderByString
            };

            postService.SetMetadataToPosts(viewModel.posts);


            return viewModel;
        }

        private int GetPageCount(int postsCount, int pageItemCount)
        {
            return (int)Math.Ceiling((float)postsCount / pageItemCount);
        }

        public IndexViewModel GetNoCensureIndexViewModel(QueryData queryData)
        {
            IQueryable<Post> postsQuery = postService.GetPostsWithoutCensure(queryData.orderBy, queryData.TagIDs);

            IndexViewModel indexNoCensureViewModel = GetNoCensureIndexViewModel(postsQuery, queryData);

            return indexNoCensureViewModel;
        }

        private IndexViewModel GetNoCensureIndexViewModel(IQueryable<Post> postsQuery, QueryData queryData)
        {
            int totalPageCount = GetPageCount(postsQuery.Count(), queryData.PostsPerPage);
            postsQuery = postService.IQueryablePostsOnPage(queryData.Page, queryData.PostsPerPage, postsQuery);
            List<Post> posts = postsQuery.ToList();
            postService.SetMetadataToPosts(posts);
            List<Tag> tags = entitiesService.GetMostPopularTags(IndexViewModelTagCount);

            IndexViewModel indexNoCensureViewModel = new IndexViewModel(postService, entitiesService)
            {
                posts = posts,
                totalPages = totalPageCount,
                Tags = tags,
                orderBy = queryData.orderByString,
                ActiveTags = queryData.TagIDs
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

        public SearchOnePageViewModel GetSearchOnePageYearViewModel(int year, string orderByString)
        {
            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel();
            viewModel.orderBy = orderByString;
            OrderBy orderBy = OrderByExntension.StringToOrderBy(orderByString);

            viewModel.posts = postService.GetPostsByYear(year, orderBy);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageStudioViewModel(int id, string orderByString)
        {
            Studio studio = entitiesService.GetStudioByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(studio);
            viewModel.orderBy = orderByString;
            OrderBy orderBy = OrderByExntension.StringToOrderBy(orderByString);

            viewModel.posts = postService.GetPostsByStudio(id, orderBy);

            postService.SetMetadataToPosts(viewModel.posts);

            return viewModel;
        }

        internal SearchOnePageViewModel GetOnePageAdminFavorite(string orderByString)
        {
            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel();
            viewModel.orderBy = orderByString;
            OrderBy orderBy = OrderByExntension.StringToOrderBy(orderByString);

            viewModel.posts = postService.GetAdminFavoritePosts(orderBy);

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

        

        public SearchOnePageViewModel GetSearchOnePageTagViewModel(int id, string orderByString)
        {
            Tag tag = entitiesService.GetTagByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(tag);
            viewModel.orderBy = orderByString;
            OrderBy orderBy = OrderByExntension.StringToOrderBy(orderByString);

            viewModel.posts = postService.GetPostsByTag(id, orderBy);

            postService.SetMetadataToPosts(viewModel.posts);


            return viewModel;
        }

        public SearchOnePageViewModel GetSearchOnePageDirectorViewModel(int id, string orderByString)
        {
            Director director = entitiesService.GetDirectorByID(id);

            SearchOnePageViewModel viewModel = GetSearchOnePageViewModel(director);
            viewModel.orderBy = orderByString;
            OrderBy orderBy = OrderByExntension.StringToOrderBy(orderByString);

            viewModel.posts = postService.GetPostsByDirector(id, orderBy);

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
