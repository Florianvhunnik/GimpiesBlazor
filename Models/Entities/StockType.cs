using System.ComponentModel.DataAnnotations;

namespace GimpiesBlazor.Models.Entities
{
    public class StockType
    {
        [Key]
        public int TypeId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
