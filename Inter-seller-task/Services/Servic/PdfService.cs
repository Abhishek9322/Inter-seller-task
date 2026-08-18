using Inter_seller_task.Repositories.Interfaces;
using Inter_seller_task.Services.Interfaces;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Inter_seller_task.Services.Servic
{
    public class PdfService : IPdfService
    {
        private readonly IProductRepository _productRepository;

        public PdfService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<byte[]> GenerateProductPdfAsync(
            int productId,
            int sellerId)
        {
            var product =
                await _productRepository.GetByIdAsync(
                    productId,
                    sellerId);

            if (product is null)
            {
                throw new KeyNotFoundException(
                    "Product not found.");
            }

            var totalPrice = product.Brands
                .Sum(x => x.Price);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);

                    page.Margin(40);

                    page.DefaultTextStyle(
                        x => x.FontSize(11));

                    page.Header()
                        .Column(column =>
                        {
                            column.Item()
                                .Text("Product Details")
                                .FontSize(24)
                                .Bold();

                            column.Item()
                                .PaddingTop(5)
                                .LineHorizontal(1);
                        });

                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            column.Item()
                                .Text(
                                    $"Product Name: {product.ProductName}")
                                .FontSize(16)
                                .Bold();

                            column.Item()
                                .PaddingTop(10)
                                .Text(
                                    $"Description: {product.ProductDescription}");

                            column.Item()
                                .PaddingTop(20)
                                .Text("Brand Details")
                                .FontSize(16)
                                .Bold();

                            foreach (var brand in product.Brands)
                            {
                                column.Item()
                                    .PaddingTop(15)
                                    .Border(1)
                                    .Padding(10)
                                    .Column(brandColumn =>
                                    {
                                        brandColumn.Item()
                                            .Text(
                                                $"Brand Name: {brand.BrandName}")
                                            .Bold();

                                        brandColumn.Item()
                                            .PaddingTop(5)
                                            .Text(
                                                $"Detail: {brand.Detail}");

                                        brandColumn.Item()
                                            .PaddingTop(5)
                                            .Text(
                                                $"Image: {brand.Image}");

                                        brandColumn.Item()
                                            .PaddingTop(5)
                                            .Text(
                                                $"Price: {brand.Price:C}");
                                    });
                            }

                            column.Item()
                                .PaddingTop(25)
                                .BorderTop(1)
                                .PaddingTop(10)
                                .Row(row =>
                                {
                                    row.RelativeItem()
                                        .Text("Total Price")
                                        .Bold()
                                        .FontSize(15);

                                    row.ConstantItem(150)
                                        .AlignRight()
                                        .Text(
                                            $"{totalPrice:C}")
                                        .Bold()
                                        .FontSize(15);
                                });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(
                            "Generated by Interview Seller API");
                });
            });

            return document.GeneratePdf();
        }


    }
}
