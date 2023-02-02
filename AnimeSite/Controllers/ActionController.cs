using AnimeSite.Database.Services;
using AnimeSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

namespace AnimeSite.Controllers
{
    public class ActionController : Controller
    {

        private readonly PostService postService;
        private readonly CommentService commentService;

        public ActionController(PostService postService, CommentService commentService)
        {
            this.postService = postService;
            this.commentService = commentService;
        }

        public int Rate(int postID, bool isPositiveRate)
        {
            IPAddress ip = HttpContext.Connection.RemoteIpAddress;
            if (ip == null)
                return -404;

            PostRate rate = postService.GetPostRate(postID, ip);

            if (rate == null)
            {
                rate = new PostRate() { PostId = postID, IsPositive = isPositiveRate, IPAddressBytes = ip.GetAddressBytes() };
                postService.AddPostRate(rate);
            }
            else
            {
                rate.IsPositive = isPositiveRate;
                postService.SaveChanges();
            }

            postService.UpdatePostRating(postID);

            Post post = postService.GetPostByID(postID);
            return post.Rating;
        }

        // TODO remove comments before prod
        //[ValidateAntiForgeryToken]
        public IActionResult CreateComment(int postID, string commentText, string commentAuthor)
        {
            IPAddress ipAddress = HttpContext.Connection.RemoteIpAddress;

            Comment userComment;


            try
            {
                userComment = commentService.GetLastUserComment(postID, ipAddress);

                

                if ((DateTime.Now - userComment.Date).Minutes < 5)
                    return Forbid("Разрешен только 1 комментарий раз в 5 минут");
            }
            catch
            {

            }

            try
            {
                postService.GetPostByID(postID);
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }

            Comment comment = new Comment() { PostID = postID, Text = commentText, AuthorName = commentAuthor, Date = System.DateTime.Now, ipAddress = ipAddress };

            postService.AddComment(comment);

            return Ok();
        }

        [Route("Download")]
        public IActionResult Download(int postID, int seriesNumber)
        {

            System.Net.IPAddress ipAddress = HttpContext.Connection.RemoteIpAddress;
            try
            {
                Post post = postService.GetPostByID(postID);
                postService.IncreementDownloadCount(post, ipAddress);

                string fileName = $"./wwwroot/vid/{post.ID}-{seriesNumber}.mp4";
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileName);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch
            {
                return NotFound("Sorry, video wasn't found.");
            }
        }


    }
}
