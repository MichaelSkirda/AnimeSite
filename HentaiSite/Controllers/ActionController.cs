using HentaiSite.Database.Services;
using HentaiSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HentaiSite.Controllers
{
    public class ActionController : Controller
    {

        private readonly PostService postService;

        public ActionController(PostService postService)
        {
            this.postService = postService;
        }

        // TODO remove comments before prod
        //[ValidateAntiForgeryToken]
        public IActionResult CreateComment(int postID, string commentText, string commentAuthor)
        {
            try
            {
                postService.GetPostByID(postID);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }

            Comment comment = new Comment() { PostID = postID, Text = commentText, AuthorName = commentAuthor, Data = System.DateTime.Now };

            postService.CreateComment(comment);

            return Ok();
        }


    }
}
