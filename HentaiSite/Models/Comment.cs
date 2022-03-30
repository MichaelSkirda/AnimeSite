using System;

namespace HentaiSite.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
    }
}
