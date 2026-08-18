using Inter_seller_task.Data;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inter_seller_task.Repositories.Repository
{
    public partial class SkillRepository
    {
        public class ProductRepository : IProductRepository
        {
            private readonly ApplicationDbContext _context;

            public ProductRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task AddAsync(Product product)
            {
                await _context.Products.AddAsync(product);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
            public async Task<Product?> GetByIdAsync(int productId,int sellerId)
            {
                return await _context.Products
                    .AsNoTracking()
                    .Include(x => x.Brands)
                    .FirstOrDefaultAsync(x =>
                        x.Id == productId &&
                        x.SellerId == sellerId);
            }
        }
    }
}
