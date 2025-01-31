using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class ShoeType
    {
        [Key]
        public int ShoeTypeId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
