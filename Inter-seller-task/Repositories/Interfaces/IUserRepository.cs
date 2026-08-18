using Inter_seller_task.Models.Entities;

namespace Inter_seller_task.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByIdWithSkillsAsync(int id);
        Task<User?> GetByIdAsync(int id);

        Task<List<User>> GetSellersAsync( int skip,int take);
        Task<int> GetSellerCountAsync();
        Task AddAsync(User user);

        Task SaveChangesAsync();
    }
}
