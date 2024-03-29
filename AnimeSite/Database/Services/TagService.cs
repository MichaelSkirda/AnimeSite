﻿using System;
using System.Collections.Generic;
using System.Linq;
using AnimeSite.Models;

namespace AnimeSite.Database.Services
{
    public class EntitiesService
    {
        private readonly ApplicationContext db;
        private const int MostPopularTagsCount = 10;

        public EntitiesService(ApplicationContext db)
        {
            this.db = db;
        }

        public void CreateTag(Tag tag)
        {
            db.Tags.Add(tag);
            db.SaveChanges();
        }

        public void CreateTagEntity(TagEntity tagEntity)
        {
            db.TagEntities.Add(tagEntity);
            db.SaveChanges();
        }

        public void CreateTagEntity(IEnumerable<TagEntity> tagEntities)
        {
            db.TagEntities.AddRange(tagEntities);
            db.SaveChanges();
        }

        public Tag GetTagByName(string name)
        {
            Tag tag = db.Tags.First(t => t.Name == name);
            return tag;
        }


        public List<Tag> GetTagsByIDs(List<int> ids)
        {
            List<Tag> tags = db.Tags.Where(t => ids.Contains(t.ID)).ToList();
            return tags;
        }

        public List<Tag> GetMostPopularTags(int count = MostPopularTagsCount)
        {
            // We need to return (X) Tags ordered by use count
            // We have Tag table which cotains Tag (Name) and (ID)
            // We have TagEntity table which contais instance of tag (Tag ID) and (Post ID)
            //
            // Find (X) the most uses Tag ID
            // Find Tags by Tag IDs
            // Return them
            // PROFIT

            List<int> tagIDs = db.TagEntities.GroupBy(t => t.TagID)
                .OrderByDescending(g => g.Count())
                .Take(count)
                .Select(g => g.Key)
                .ToList();

            List<Tag> MostPopularTags = GetTagsByIDs(tagIDs);




            return MostPopularTags;
        }

        public Studio GetStudioByID(int id)
        {
            return db.Studios.First(s => s.ID == id);
        }

        public Director GetDirectorByID(int id)
        {
            return db.Directors.First(d => d.ID == id);
        }

        public Tag GetTagByID(int id)
        {
            return db.Tags.First(t => t.ID == id);
        }


    }
}
