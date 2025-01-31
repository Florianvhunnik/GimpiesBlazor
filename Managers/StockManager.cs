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
