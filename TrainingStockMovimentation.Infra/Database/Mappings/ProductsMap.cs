using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Infra.Database.Mappings
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Description) 
                .HasMaxLength(200);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasDefaultValue(0);

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Supplier");
        }
    }
}
