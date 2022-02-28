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

        private readonly int PagePostsCount = 4;

        public HomeController(ViewModelService viewModelService)
        {
            this.viewModelService = viewModelService;
        }

        public IActionResult Index(string orderby, int page = 1, int? year = null, int? tag = null)
        {


            IndexViewModel viewModel = viewModelService.GetIndexViewModel(PagePostsCount, orderby, page, year, tag);


            var query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());

            query.Remove("orderby");

            string queryString = query.ToString();
            query.Remove("page");
            string queryStringWithoutPage = query.ToString();

            if(queryString == null || queryString == "")
            {
                queryString = "";
            }


            viewModel.queryString = queryString;
            viewModel.queryStringWithoutPage = queryStringWithoutPage;

            return View(viewModel);
        }

        [Route("top100")]
        public IActionResult TopHundred()
        {
            //List<Post> posts = postService.GetTopHundredByRating();
            return View();
        }

        [Route("Post")]
        public IActionResult Post(int id)
        {

            try
            {
                PostViewModel postViewModel = viewModelService.GetPostViewModel(id);
                return View(postViewModel);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            
        }

        public IActionResult Post(PostViewModel postViewModel)
        {
            return View(postViewModel);
        }

        [Route("GetRandomPost")]
        public IActionResult GetRandomPost()
        {
            PostViewModel postViewModel = viewModelService.GetPostViewModeRandom();
            return RedirectToActionPermanent("Post", postViewModel);
        }

    }
}