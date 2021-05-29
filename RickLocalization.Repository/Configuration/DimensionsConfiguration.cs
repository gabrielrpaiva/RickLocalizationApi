using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickLocalization.Domain.Entities;

namespace RickLocalization.Repository.Configuration
{
    public class DimensionsConfiguration : IEntityTypeConfiguration<DimensionsEntity>
    {
        public void Configure(EntityTypeBuilder<DimensionsEntity> builder)
        {
            builder.ToTable("TBL_DIMENSIONS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();


            builder.HasData(new HumansEntity { Id = 1, Name = "CRONENBERG C-137" });
            builder.HasData(new HumansEntity { Id = 2, Name = "WASTELAND" });
            builder.HasData(new HumansEntity { Id = 3, Name = "DOG" });
            builder.HasData(new HumansEntity { Id = 4, Name = "TOILET" });
            builder.HasData(new HumansEntity { Id = 5, Name = "FURNITURE/PIZZA/PHONE WORLDS" });
            builder.HasData(new HumansEntity { Id = 6, Name = "NEW CRONENBERG WORLD" });
            builder.HasData(new HumansEntity { Id = 7, Name = "FROOPYLAND" });
            builder.HasData(new HumansEntity { Id = 8, Name = "TESTICLE MONSTER WORLD" });
            builder.HasData(new HumansEntity { Id = 9, Name = "GREASY GRANDMA WORLD" });
            builder.HasData(new HumansEntity { Id = 10, Name = "HAMSTER-IN-BUTT WORLD" });
        }
    }
}
