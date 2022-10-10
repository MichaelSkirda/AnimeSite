    using System;
using System.Collections.Generic;
using HentaiSite.Database.Services;
using HentaiSite.Models;
using HentaiSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HentaiSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly ViewModelService viewModelService;

        private readonly int PagePostsCount = 20;

        public HomeController(ViewModelService viewModelService)
        {
            this.viewModelService = viewModelService;
        }

        public IActionResult Index(string orderBy, string s = "", int page = 1, int? year = null, List<int> tag = null)
        {
            QueryData queryData = new QueryData()
            {
                PostsPerPage = PagePostsCount,
                orderByString = orderBy,
                Page = page,
                s = s,
                ReleaseYear = year,
                TagIDs = tag
            };
            IndexViewModel viewModel = viewModelService.GetIndexViewModel(queryData);

            viewModel.queryStringWithoutOrderBy = GetQueryFormatedStringWithoutOrderBy();
            viewModel.queryStringWithoutPage = GetQueryFormatedStringWithoutPage();

            return View(viewModel);
        }

        private string GetQueryFormatedStringWithoutOrderBy()
        {
            var query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            query.Remove("orderby");
            return FormatQueryString(query);
        }

        private string GetQueryFormatedStringWithoutPage()
        {
            var query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            query.Remove("page");
            return FormatQueryString(query);
        }


        private string FormatQueryString(System.Collections.Specialized.NameValueCollection query)
        {
            string queryString = query.ToString();

            if (queryString == null || queryString == "")
                return "";
            else
                return "&" + queryString;
        }

        [Route("years")]
        public IActionResult Years()
        {
            YearsViewModel yearsViewModel = viewModelService.GetYearsViewModel();
            return View(yearsViewModel);
        }

        [Route("contact_us")]
        public IActionResult ContactUs()
        {
            BasicViewModel basicViewModel = viewModelService.GetBasicViewModel();
            return View(basicViewModel);
        }


        [Route("copyright")]
        public IActionResult Copyright()
        {
            BasicViewModel basicViewModel = viewModelService.GetBasicViewModel();
            return View(basicViewModel);
        }

        [Route("nocensure")]
        public IActionResult NoCensure(string orderBy, int page = 1, List<int> tag = null)
        {
            QueryData queryData = new QueryData()
            {
                PostsPerPage = PagePostsCount,
                orderByString = orderBy,
                Page = page,
                TagIDs = tag
            };
            IndexViewModel noCunsureViewModel = viewModelService.GetNoCensureIndexViewModel(queryData);
            noCunsureViewModel.ActiveTags = tag;
            noCunsureViewModel.orderBy = orderBy;

            return View("Index", noCunsureViewModel);
        }

        [Route("alltags")]
        public IActionResult AllTags()
        {
            AllTagsViewModel allTagsViewModel = viewModelService.GetAllTagsViewModel();

            return View(allTagsViewModel);
        }

        [Route("top100")]
        public IActionResult TopHundred(string orderby)
        {
            SearchOnePageViewModel onePageViewModel = viewModelService.GetOnePageTopHundredViewModel(orderby);
            onePageViewModel.orderBy = orderby;
            return View("tophundred", onePageViewModel);
        }

        [Route("Post/{id}")]
        public IActionResult Post(int id)
        {
            PostViewModel postViewModel;
            try
            {
                postViewModel = viewModelService.GetPostViewModel(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            System.Net.IPAddress ipAddress = HttpContext.Connection.RemoteIpAddress;
            viewModelService.AddView(ipAddress, postViewModel.post);

            return View(postViewModel);

        }

        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("RandomPost")]
        public IActionResult RandomPost()
        {
            Post post = viewModelService.GetRandomPostID();
            return LocalRedirectPermanent($"~/Post/{post.ID}");
        }


        [Route("Studio/{id}")]
        public IActionResult Studio(int id, string orderby)
        {
            try
            {
                SearchOnePageViewModel searchOnePageViewModel = viewModelService.GetSearchOnePageStudioViewModel(id, orderby);
                return View("SearchOnePage", searchOnePageViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [Route("Director/{id}")]
        public IActionResult Director(int id, string orderby)
        {
            try
            {
                SearchOnePageViewModel searchOnePageViewModel = viewModelService.GetSearchOnePageDirectorViewModel(id, orderby);
                return View("SearchOnePage", searchOnePageViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [Route("Tag/{id}")]
        public IActionResult Tag(int id, string orderby)
        {
            try
            {
                SearchOnePageViewModel searchOnePageViewModel = viewModelService.GetSearchOnePageTagViewModel(id, orderby);
                return View("SearchOnePage", searchOnePageViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [Route("Year/{year}")]
        public IActionResult Year(int year, string orderby)
        {
            try
            {
                SearchOnePageViewModel searchOnePageViewModel = viewModelService.GetSearchOnePageYearViewModel(year, orderby);
                return View("SearchOnePage", searchOnePageViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [Route("AdminFavorite")]
        public IActionResult AdminFavorite(string orderby)
        {
            SearchOnePageViewModel searchOnePageViewModel = viewModelService.GetOnePageAdminFavorite(orderby);
            return View("SearchOnePage", searchOnePageViewModel);
        }

        public JsonResult GetPostsByTags(List<int> tagIDs)
        {
            var posts = viewModelService.GetPostsJSONByTagsIDs(tagIDs);

            return Json(posts);

        }

        [Route("about_cookie")]
        public IActionResult AboutCookie()
        {
            BasicViewModel basicViewModel = viewModelService.GetBasicViewModel();
            return View(basicViewModel);
        }

    }
}