using Inter_seller_task.Data;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inter_seller_task.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {

            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByIdWithSkillsAsync(int id)
        {
            return await _context.Users
                       .Include(x => x.SellerSkills)
                       .ThenInclude(x => x.Skill)
                       .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
