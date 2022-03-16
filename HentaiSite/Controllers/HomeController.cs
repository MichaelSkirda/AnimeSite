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

        public IActionResult Index(string orderby, string s = "", int page = 1, int? year = null, List<int> tag = null)
        {


            IndexViewModel viewModel = viewModelService.GetIndexViewModel(PagePostsCount, orderby, page, s, year, tag);
            viewModel.orderBy = orderby;
            viewModel.ActiveTags = tag;

            // Get Query parameters
            var query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());

            query.Remove("page");
            // Query string without orderby and page.
            string queryStringWithoutPage = query.ToString();

            // Restore query with page
            query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());

            query.Remove("orderby");
            // Query without orderby. Нужен, чтобы во View добавить требуемую сортировку на каждую кнопку, сохраняя параметры
            string queryString = query.ToString();
            

            if(queryString == null || queryString == "")
            {
                queryString = "";
            }
            else
            {
                queryString = "&" + queryString;
            }

            if (queryStringWithoutPage == null || queryStringWithoutPage == "")
            {
                queryStringWithoutPage = "";
            }
            else
            {
                queryStringWithoutPage = "&" + queryStringWithoutPage;
            }


            viewModel.queryString = queryString;
            viewModel.queryStringWithoutPage = queryStringWithoutPage;

            return View(viewModel);
        }

        [Route("alltags")]
        public IActionResult AllTags()
        {
            AllTagsViewModel allTagsViewModel = viewModelService.GetAllTagsViewModel();

            return View(allTagsViewModel);
        }

        [Route("top100")]
        public IActionResult TopHundred(string topBy)
        {
            SearchOnePageViewModel onePageViewModel = viewModelService.GetOnePageTopHundredViewModel(topBy);
            return View("SearchOnePage", onePageViewModel);
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

    }
}