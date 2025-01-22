using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GimpiesBlazor.Models.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [ForeignKey(nameof(Brand))]
        public int FkBrandId { get; set; }

        [ForeignKey(nameof(Color))]
        public int FkColorId { get; set; }

        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        public int Size { get; set; }
        public int Count { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public virtual required Color Color { get; set; }
        public virtual required Brand Brand { get; set; }

    }
}