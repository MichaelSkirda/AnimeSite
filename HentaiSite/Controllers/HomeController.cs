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

        private readonly PostService postService;

        private readonly int PagePostsCount = 20;

        public HomeController(PostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index(string orderby)
        {

            List<Post> posts = postService.GetPosts(orderby, PagePostsCount);

            postService.SetMetadataToPosts(posts);

            var query = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());

            query.Remove("orderby");

            string queryString = query.ToString();

            if(queryString == null || queryString == "")
            {
                queryString = "";
            }
            else
            {
                queryString = "&" + queryString;
            }

            IndexViewModel viewModel = new IndexViewModel()
            {
                posts = posts,
                queryString = queryString
            };

            return View(viewModel);
        }

        [Route("top100")]
        public IActionResult TopHundred()
        {
            List<Post> posts = postService.GetTopHundredByRating();
            return View(posts);
        }

        [Route("Post")]
        public IActionResult Post(int id)
        {
            Post post;
            try
            {
                post = postService.GetPostByID(id);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
            postService.SetMetadataToPosts(post);
            return View(post);
        }

    }
}