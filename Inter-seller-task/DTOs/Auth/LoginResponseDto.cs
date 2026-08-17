namespace Inter_seller_task.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
