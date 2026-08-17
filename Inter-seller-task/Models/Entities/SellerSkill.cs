namespace Inter_seller_task.Models.Entities
{
    public class SellerSkill
    {
        public int SellerId { get; set; }

        public User Seller { get; set; } = null!;

        public int SkillId { get; set; }

        public Skill Skill { get; set; } = null!;
    }
}
