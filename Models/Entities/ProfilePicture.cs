using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class ProfilePicture
    {
        [Key]
        public int ProfilePictureId { get; set; }

        [MaxLength(255)]
        public string Link { get; set; } = string.Empty;
    }
}
