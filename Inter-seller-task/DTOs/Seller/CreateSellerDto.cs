namespace Inter_seller_task.DTOs.Seller
{
    public class CreateSellerDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public List<int> SkillIds { get; set; } = new();

        public string Password { get; set; } = string.Empty;
    }
}
