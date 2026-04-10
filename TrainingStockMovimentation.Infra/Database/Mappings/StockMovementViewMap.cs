using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Infra.Database.Mappings
{
    public class StockMovementViewMap : IEntityTypeConfiguration<StockMovementView>
    {
        public void Configure(EntityTypeBuilder<StockMovementView> builder)
        {
            builder.ToView("vw_StockMovementDetailed");

            builder.HasNoKey();
        }
    }
}
