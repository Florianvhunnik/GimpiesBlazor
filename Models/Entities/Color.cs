using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
