using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RickLocalization.Domain.Entities;

namespace RickLocalization.Repository.Configuration
{
    public class HumansConfiguration : IEntityTypeConfiguration<HumansEntity>
    {
        public void Configure(EntityTypeBuilder<HumansEntity> builder)
        {
            builder.ToTable("TBL_HUMANS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

            builder.HasData(new HumansEntity { Id = 1, Name = "Rick Sanchez" });
            builder.HasData(new HumansEntity { Id = 2, Name = "Morty" });
        }
    }
}
