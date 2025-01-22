using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GimpiesBlazor.Models.Entities
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [ForeignKey(nameof(Stock))]
        public int FkStockId { get; set; }

        [ForeignKey(nameof(Account))]
        public int FkAccountId { get; set; }

        public int NumberSold { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalSalePrice { get; set; }
        
        public DateTime SaleDate { get; set; }

        public virtual required Account Account { get; set; }
        public virtual required Stock Stock { get; set; }
    }
}