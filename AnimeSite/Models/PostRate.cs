using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AnimeSite.Models
{
    public class PostRate
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public bool IsPositive { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public byte[] IPAddressBytes { get; set; }

        [NotMapped]
        public IPAddress IPAddress
        {
            get { return new IPAddress(IPAddressBytes); }
            set { IPAddressBytes = value.GetAddressBytes(); }
        }
    }
}
