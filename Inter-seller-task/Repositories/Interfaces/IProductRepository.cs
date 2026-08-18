using Inter_seller_task.Models.Entities;

namespace Inter_seller_task.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task SaveChangesAsync();

        Task<Product?> GetByIdAsync(
           int productId,
           int sellerId);
    }

}
