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
            try
            {
                context.Stock.Update(stock);
                await context.SaveChangesAsync();
            }
            catch
            {

            }
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

        public async Task<List<Brand>> GetBrands()
        {
            return await context.Brands.ToListAsync();
        }

        public async Task<List<ShoeType>> GetShoeTypes()
        {
            return await context.ShoeTypes.ToListAsync();
        }

        public async Task<List<Color>> GetColors()
        {
            return await context.Colors.ToListAsync();
        }

        public async Task<Brand?> GetBrandById(int brandId)
        {
            return await context.Brands.FirstOrDefaultAsync(b => b.BrandId == brandId);
        }

        public async Task<ShoeType?> GetShoeTypeById(int typeId)
        {
            return await context.ShoeTypes.FirstOrDefaultAsync(t => t.ShoeTypeId == typeId);
        }

        public async Task<Color?> GetColorById(int colorId)
        {
            return await context.Colors.FirstOrDefaultAsync(c => c.ColorId == colorId);
        }

        public async Task AddBrand(Brand brand)
        {
            if (!await context.Brands.AnyAsync(b => b.Name == brand.Name))
            {
                context.Brands.Add(brand);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddShoeType(ShoeType shoeType)
        {
            if (!await context.ShoeTypes.AnyAsync(t => t.Name == shoeType.Name))
            {
                context.ShoeTypes.Add(shoeType);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddColor(Color color)
        {
            if (!await context.Colors.AnyAsync(c => c.Name == color.Name))
            {
                context.Colors.Add(color);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> AddSale(Sale sale)
        {
            context.Sales.Add(sale);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Sale>> GetSalesData()
        {
            return await context.Sales
                .Include(s => s.Stock)
                .ThenInclude(stock => stock.Brand)
                .ToListAsync();
        }
    }
}
