using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AnimeSite.Models
{
    public class UserDownload
    {
        public int ID { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public byte[] IPAddressBytes { get; set; }
        public int PostID { get; set; }

        [NotMapped]
        public IPAddress ipAddress
        {
            get { return new IPAddress(IPAddressBytes); }
            set { IPAddressBytes = value.GetAddressBytes(); }
        }
    }
}
