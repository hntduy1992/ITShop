using ITShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITShop.WebApi.EF.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductsInCategories");
            builder.HasKey(x=>new { x.ProductId, x.CategoryId });

            builder.HasOne(x=>x.Product).WithMany(x=>x.ProductInCategories).HasForeignKey(x=>x.ProductId);
            builder.HasOne(x=>x.Category).WithMany(x=>x.ProductInCategories).HasForeignKey(x=>x.CategoryId);
        }
    }
}
