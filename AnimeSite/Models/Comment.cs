using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace AnimeSite.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public byte[] IPAddressBytes { get; set; }

        [NotMapped]
        public IPAddress ipAddress
        {
            get { return new IPAddress(IPAddressBytes); }
            set { IPAddressBytes = value.GetAddressBytes(); }
        }
    }
}
