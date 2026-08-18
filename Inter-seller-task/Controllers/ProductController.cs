using Inter_seller_task.DTOs.Product;
using Inter_seller_task.Helpers;
using Inter_seller_task.Services.Interfaces;
using Inter_seller_task.Services.Servic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_seller_task.Controllers
{
    [Route("api/Product/Create")]
    [ApiController]
    [Authorize(Roles = "Seller")]
    public class ProductController : ControllerBase
    {

        private readonly IPdfService _pdfService;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IPdfService pdfService )
        {
            _productService = productService;
            _pdfService = pdfService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto request)
        {

            var sellerId = User.GetUserId();


            var response = await _productService.CreateProductAsync(request,sellerId);

            return Ok(response);
        }


        [HttpGet("{id:int}/pdf")]
        public async Task<IActionResult> GetProductPdf( int id)
        {
            var sellerId = User.GetUserId();

            var pdf = await _pdfService
                .GenerateProductPdfAsync(
                    id,
                    sellerId);

            return File(
                pdf,
                "application/pdf",
                $"product-{id}.pdf");
        }
    }
}
