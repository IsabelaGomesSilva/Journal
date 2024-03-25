using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalJournal.Domain.Models;


namespace Stories.Data.Configuration
{
    public class GoalEntityConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goal");

            builder.Property(g => g.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(g => g.Name)
                  .IsRequired()
                  .HasMaxLength(100)
                  .IsUnicode(false);
            builder.Property(g => g.Description)
                   .IsRequired()
                   .HasMaxLength(400)
                   .IsUnicode(false);
            builder.Property(g => g.StartDate)
                   .HasColumnType("DATETIME");
            builder.Property(g => g.LimitDate)
                   .HasColumnType("DATETIME");

            builder.Property(g => g.LevelId);
            builder.HasOne<Level>()
                   .WithMany()
                   .HasForeignKey(g => g.LevelId)
                   .HasConstraintName("FK_Level_Goal");

            builder.Property(g => g.UserId)
                   .IsRequired();
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(g => g.UserId)
                   .HasConstraintName("FK_User_Goal");

        }
    }
}