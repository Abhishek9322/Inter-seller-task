using System.Security.Claims;

namespace Inter_seller_task.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId( this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(
                ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userId, out var id))
            {
                throw new UnauthorizedAccessException(
                    "User ID claim is missing.");
            }

            return id;
        }
    }
}
