namespace Inter_seller_task.Services.Interfaces
{
    public interface IPdfService
    {
        Task<byte[]> GenerateProductPdfAsync(
            int productId,
            int sellerId);
    }
}
