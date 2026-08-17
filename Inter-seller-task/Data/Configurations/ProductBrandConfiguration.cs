using Inter_seller_task.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter_seller_task.Data.Configurations
{
    public class ProductBrandConfiguration: IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BrandName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Detail)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Brands)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ProductId);
        }
    }
}
