using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AnimeSite.Models;
using AnimeSite.Database.Services;
using System;
using System.Collections.Generic;
using AnimeSite.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AnimeSite.Controllers
{
    public class AdminController : Controller
    {

        private readonly EntitiesService entitiesService;
        private readonly PostService postService;
        private readonly ViewModelService viewModelService;
        private readonly IWebHostEnvironment appEnvironment;

        public AdminController(EntitiesService entitiesService, PostService postService,
            ViewModelService viewModelService, IWebHostEnvironment appEnvironment)
        {
            this.entitiesService = entitiesService;
            this.postService = postService;
            this.viewModelService = viewModelService;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            BasicViewModel basicViewModel = viewModelService.GetBasicViewModel();
            return View(basicViewModel);
        }

        public IActionResult CreatePostPanel()
        {
            BasicViewModel basicViewModel = viewModelService.GetBasicViewModel();
            return View(basicViewModel);
        }

        public IActionResult CreatePost(Post post, IFormFile previewImage,
            string fTags, string fStudios, string fDirectors, string password)
        {
            if (password != "Dn129DHJ39D*#qz")
                return NotFound();

            post.ImgFormat = Path.GetExtension(previewImage.FileName);

            postService.AddPost(post);
            postService.AddTagsToPost(post, fTags);
            postService.AddStudiosToPost(post, fStudios);
            postService.AddDirectorsToPost(post, fDirectors);

            SavePreview(previewImage, post.ID);

            return RedirectToActionPermanent("Post", "Home", new { id = post.ID });
        }

        private void SavePreview(IFormFile previewImage, int postId)
        {
            string path = $"/img/thumbnail/3-2-{postId}{Path.GetExtension(previewImage.FileName)}";

            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                previewImage.CopyTo(fileStream);

            }
        }

    }
}
