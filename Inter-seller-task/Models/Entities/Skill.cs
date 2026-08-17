using Inter_seller_task.Models.Common;

namespace Inter_seller_task.Models.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<SellerSkill> SellerSkills { get; set; }= new List<SellerSkill>();
    }
}
