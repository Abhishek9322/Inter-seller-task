namespace Inter_seller_task.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<bool> AllExistAsync(List<int> skillIds);
    }
}
