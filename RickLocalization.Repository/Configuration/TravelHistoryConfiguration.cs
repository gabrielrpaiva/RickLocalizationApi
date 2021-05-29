using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickLocalization.Domain.Entities;
using System;

namespace RickLocalization.Repository.Configuration
{
    public class TravelHistoryConfiguration : IEntityTypeConfiguration<TravelHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<TravelHistoryEntity> builder)
        {
            builder.ToTable("TBL_TRAVEL_HISTORY");
            builder.HasKey(x => x.Id);            
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdHumansByDimensions).HasColumnName("ID_HUMANS_DIMENSION").IsRequired();
            builder.Property(x => x.IdTargetDimension).HasColumnName("ID_TARGET_DIMENSION").IsRequired();
            builder.Property(x => x.TravelDate).HasColumnName("TRAVEL_DATE").IsRequired();


            builder.HasOne(x => x.Dimensions)
                      .WithMany()
                      .HasForeignKey(x => x.IdTargetDimension)
                      .HasConstraintName("FK_TRAVEL_HISTORY_DIMENSIONS")
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.HumansByDimensions)
                       .WithMany(i => i.TravelHistories)
                       .HasForeignKey(x => x.IdHumansByDimensions)  
                       .HasConstraintName("FK_TRAVEL_HISTORY_HUMANS_DIMENSIONS")
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict);



            DateTime baseDate = new DateTime(2021, 1, 1, 8, 0, 15);
            builder.HasData(new TravelHistoryEntity { Id = 1, IdHumansByDimensions = 1, IdTargetDimension = 3, TravelDate = baseDate.AddDays(2) });
            builder.HasData(new TravelHistoryEntity { Id = 2, IdHumansByDimensions = 1, IdTargetDimension = 4, TravelDate = baseDate.AddMonths(3) });


            builder.HasData(new TravelHistoryEntity { Id = 3, IdHumansByDimensions = 2, IdTargetDimension = 6, TravelDate = baseDate.AddDays(2) });
            builder.HasData(new TravelHistoryEntity { Id = 4, IdHumansByDimensions = 2, IdTargetDimension = 2, TravelDate = baseDate.AddMonths(3) });
        }


    }
}
