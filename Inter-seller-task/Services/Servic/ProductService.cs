using AutoMapper;
using Inter_seller_task.DTOs.Product;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Services.Interfaces;
using Inter_seller_task.Repositories.Interfaces;

namespace Inter_seller_task.Services.Servic
{
    public partial class SellerService
    {
        public class ProductService : IProductService
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public ProductService(
                IProductRepository productRepository,
                IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ProductResponseDto> CreateProductAsync(
                CreateProductDto request,
                int sellerId)
            {
                var product = _mapper.Map<Product>(request);

                // SellerId comes from JWT, NOT from request
                product.SellerId = sellerId;

                await _productRepository.AddAsync(product);

                await _productRepository.SaveChangesAsync();

                return _mapper.Map<ProductResponseDto>(product);
            }
        }
    }
    
}
