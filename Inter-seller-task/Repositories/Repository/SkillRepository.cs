using Inter_seller_task.Data;
using Inter_seller_task.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inter_seller_task.Repositories.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AllExistAsync(List<int> skillIds)
        {
            var distinctSkillIds = skillIds
            .Distinct()
            .ToList();

            var existingSkillCount = await _context.Skills
                .CountAsync(x => distinctSkillIds.Contains(x.Id));

            return existingSkillCount == distinctSkillIds.Count;
        }
    }
}
