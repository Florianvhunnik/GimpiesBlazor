using GimpiesBlazor.Data;
using GimpiesBlazor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GimpiesBlazor.Managers
{
    public class StockManager(AppDbContext context)
    {
        public async Task<List<Stock>> GetStock()
        {
            return await context.Stock
                .Include(s => s.Brand)
                .Include(s => s.Color)
                .Include(s => s.ShoeType)
                .Where(s => s.IsActive)
                .ToListAsync();
        }

        public async Task AddStock(Stock stock)
        {
            var existingBrand = await context.Brands
                .FirstOrDefaultAsync(b => b.Name == stock.Brand.Name);

            if (existingBrand != null)
                stock.Brand = existingBrand;
            else
                context.Brands.Add(stock.Brand);

            var existingColor = await context.Colors
                .FirstOrDefaultAsync(c => c.Name == stock.Color.Name);

            if (existingColor != null)
                stock.Color = existingColor;
            else
                context.Colors.Add(stock.Color);

            var existingShoeType = await context.ShoeTypes
                .FirstOrDefaultAsync(t => t.Name == stock.ShoeType.Name);

            if (existingShoeType != null)
                stock.ShoeType = existingShoeType;
            else
                context.ShoeTypes.Add(stock.ShoeType);

            stock.IsActive = true;

            context.Stock.Add(stock);
            await context.SaveChangesAsync();
        }

        public async Task UpdateStock(Stock stock)
        {
            context.Stock.Update(stock);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStock(int stockId)
        {
            var stock = await context.Stock.FindAsync(stockId);

            if (stock is null)
                return;
            if (!stock.IsActive)
                return;

            stock.IsActive = false;
            await context.SaveChangesAsync();
        }

    }
}
