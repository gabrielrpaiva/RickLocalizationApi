using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickLocalization.Domain.Entities;

namespace RickLocalization.Repository.Configuration
{
    public class HumansByDimensionsConfiguration : IEntityTypeConfiguration<HumansByDimensionsEntity>
    {
        public void Configure(EntityTypeBuilder<HumansByDimensionsEntity> builder)
        {
            builder.ToTable("TBL_HUMANS_BY_DIMENSIONS");
            builder.HasKey(x => x.Id);
            builder.HasKey(table => new {
                table.IdHuman,
                table.IdDimension
            });
            
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdHuman).HasColumnName("ID_HUMAN").IsRequired();
            builder.Property(x => x.IdDimension).HasColumnName("ID_DIMENSION").IsRequired();
            builder.Property(x => x.IdResponsibleForWhichHuman).HasColumnName("ID_RESPONSIBLE_FOR_WHICH_HUMAN");
            builder.Property(x => x.IdHumanResponsibleForMe).HasColumnName("ID_HUMAN_RESPONSIBLE_FOR_ME");


            builder.HasOne(x => x.Human)
                .WithMany()
                .HasForeignKey(x => x.IdHuman)
                .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_HUMAN")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Dimensions)
             .WithMany()
             .HasForeignKey(x => x.IdDimension)
             .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_DIMENSIONS")
             .IsRequired()
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ResponsibleForWhichHuman)
               .WithMany()
               .HasForeignKey(x => x.IdResponsibleForWhichHuman)
               .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_RESPONSIBLE_FOR_WHICH_HUMAN")              
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HumanResponsibleForMe)
                       .WithMany()
                       .HasForeignKey(x => x.IdHumanResponsibleForMe)
                       .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_HUMAN_RESPONSIBLE_FOR_ME")
                       .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(new HumansByDimensionsEntity { Id = 1, IdDimension = 1, IdHuman = 1, IdResponsibleForWhichHuman = 2 });
            builder.HasData(new HumansByDimensionsEntity { Id = 1, IdDimension = 1, IdHuman = 2, IdHumanResponsibleForMe = 1 });
        }
    }
}
