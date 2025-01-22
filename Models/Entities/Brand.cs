using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
