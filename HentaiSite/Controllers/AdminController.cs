using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HentaiSite.Models;
using HentaiSite.Database.Services;
using System;
using System.Collections.Generic;

namespace HentaiSite.Controllers
{
    public class AdminController : Controller
    {

        private readonly TagService tagService;
        private readonly PostService postService;

        public AdminController(TagService tagService, PostService postService)
        {
            this.tagService = tagService;
            this.postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePost(string name, string description, int seriesCount, int releaseYear, int? endingYear, int duration, string tags)
        {
            // Create post
            Post post = new Post()
            {
                Name = name,
                Description = description,
                SeriesCount = seriesCount,
                EndingYear = endingYear,
                Duration = duration,
                IsVisible = false,
            };
            // Save them
            postService.CreatePost(post);


            if (tags == null)
            {
                tags = "";
            }

            List<Tag> realTags = new List<Tag>();
            List<TagEntity> tagEntities = new List<TagEntity>();

            // For each tag to add
            foreach (string tagName in tags.Split(';'))
            {
                Tag tag;
                // If tag already exist find them
                try
                {
                     tag = tagService.GetTagByName(tagName);
                }
                catch(InvalidOperationException)
                {
                    // If tag doen't exist create them
                    tag = new Tag()
                    {
                        Name = tagName,
                    };

                    tagService.CreateTag(tag);
                }

                realTags.Add(tag);

            }


            foreach(Tag tag in realTags)
            {
                // Create tag entity and save
                TagEntity tagEntity = new TagEntity()
                {
                    PostID = post.ID,
                    TagID = tag.ID
                };

                tagEntities.Add(tagEntity);
            }

            tagService.CreateTagEntity(tagEntities);
            


            return RedirectToActionPermanent("Index");
        }

    }
}
