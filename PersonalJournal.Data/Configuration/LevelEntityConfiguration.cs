using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalJournal.Domain.Models;

namespace Stories.Data.Configuration
{
    public class LevelEntityConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Level");

            builder.Property(l => l.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(l => l.Description)
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);       
        }
    }
}