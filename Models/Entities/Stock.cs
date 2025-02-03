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

        [ForeignKey(nameof(ShoeType))]
        public int FkTypeId { get; set; }

        public int Size { get; set; }
        public int Count { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public virtual required Color Color { get; set; }
        public virtual required Brand Brand { get; set; }
        public virtual required ShoeType ShoeType { get; set; }


        [NotMapped]
        public int SelectedBrandId
        {
            get => Brand.BrandId;
            set => Brand = new Brand { BrandId = value };
        }

        [NotMapped]
        public int SelectedShoeTypeId
        {
            get => ShoeType.ShoeTypeId;
            set => ShoeType = new ShoeType { ShoeTypeId = value };
        }

        [NotMapped]
        public int SelectedColorId
        {
            get => Color.ColorId;
            set => Color = new Color { ColorId = value };
        }
    }
}