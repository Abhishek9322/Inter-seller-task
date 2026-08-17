using Inter_seller_task.Models.Entities;

namespace Inter_seller_task.Repositories.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
