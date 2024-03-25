using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalJournal.Domain.Models;

namespace Stories.Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(u => u.Name)
                   .HasMaxLength(100)
                   .IsRequired()
                   .IsUnicode(false);
            builder.Property(u => u.Email)
               .HasMaxLength(255)
               .IsRequired();
            builder.Property(u => u.Password)
                .HasMaxLength(15)
                .IsRequired();

        }
    }
}