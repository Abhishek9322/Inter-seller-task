using Inter_seller_task.Models.Common;

namespace Inter_seller_task.Models.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public Role Role { get; set; }

        public ICollection<SellerSkill> SellerSkills { get; set; } = new List<SellerSkill>();

        public ICollection<Product> Products { get; set; }= new List<Product>();
    }
}
