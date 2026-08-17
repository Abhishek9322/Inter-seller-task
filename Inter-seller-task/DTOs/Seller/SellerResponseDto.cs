namespace Inter_seller_task.DTOs.Seller
{
    public class SellerResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public List<string> Skills { get; set; } = new();

        public DateTime CreatedAt { get; set; }
    }
}
