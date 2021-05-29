using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickLocalization.Domain.Entities;

namespace RickLocalization.Repository.Configuration
{
    public class TravelHistoryConfiguration : IEntityTypeConfiguration<TravelHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<TravelHistoryEntity> builder)
        {
            builder.ToTable("TBL_TRAVEL_HISTORY");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdTargetDimension).HasColumnName("ID_TARGET_DIMENSION").IsRequired();
            builder.Property(x => x.TravelDate).HasColumnName("TRAVEL_DATE").IsRequired();
        }

    }
}
