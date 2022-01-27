using System;
using System.Collections.Generic;
using System.Linq;
using HentaiSite.Models;

namespace HentaiSite.Database.Services
{
    public class TagService
    {
        private readonly ApplicationContext db;

        public TagService(ApplicationContext db)
        {
            this.db = db;
        }

        public Tag GetTagByName(string name)
        {
            Tag tag = db.Tags.First(t => t.Name == name);
            return tag;
        }

        public Tag GetTagByID(int id)
        {
            Tag tag = db.Tags.First(t => t.ID == id);
            return tag;
        }

        public List<Tag> GetTagsByIDs(int[] ids)
        {
            List<Tag> tags = db.Tags.Where(t => ids.Contains(t.ID)).ToList();
            return tags;
        }

    }
}
