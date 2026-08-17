using Inter_seller_task.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inter_seller_task.Data.Configurations
{
    public class SellerSkillConfiguration: IEntityTypeConfiguration<SellerSkill>
    {
        public void Configure(EntityTypeBuilder<SellerSkill> builder)
        {
            builder.HasKey(x => new
            {
                x.SellerId,
                x.SkillId
            });

            builder.HasOne(x => x.Seller)
                .WithMany(x => x.SellerSkills)
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Skill)
                .WithMany(x => x.SellerSkills)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
