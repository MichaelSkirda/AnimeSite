using AnimeSite.Models;
using System.Linq;
using System.Net;

namespace AnimeSite.Database.Services
{
    public class CommentService
    {
        private readonly ApplicationContext db;

        public CommentService(ApplicationContext db)
        {
            this.db = db;
        }

        public Comment GetLastUserComment(int postID, IPAddress ipAddress)
        {
            return db.Comments.OrderByDescending(c => c.Date).First(c => c.PostID == postID && c.IPAddressBytes == ipAddress.GetAddressBytes());
        }

    }
}
