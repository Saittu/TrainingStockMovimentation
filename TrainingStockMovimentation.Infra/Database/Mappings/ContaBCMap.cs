using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Infra.Database.Mappings
{
    public class ContaBCMap : IEntityTypeConfiguration<ContaBC>
    {
        public void Configure(EntityTypeBuilder<ContaBC> builder)
        {
            builder.ToTable("ContaBC");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.Number);

            builder.Property(x => x.Balance);

            builder.Property(x => x.FlContaAtiva);
        }
    }
}
