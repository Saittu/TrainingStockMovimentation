using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Infra.Mappings
{
    public class StockMovementMap : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.stockMovements)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products");
        }
    }
}
