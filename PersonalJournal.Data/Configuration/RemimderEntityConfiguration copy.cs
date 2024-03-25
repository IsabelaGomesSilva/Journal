using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalJournal.Domain.Models;

namespace Stories.Data.Configuration
{
       public class RemimderEntityConfiguration : IEntityTypeConfiguration<Remimder>
       {
              public void Configure(EntityTypeBuilder<Remimder> builder)
              {
                     builder.ToTable("Remimder");

                     builder.Property(r => r.Id)
                            .ValueGeneratedOnAdd();
                     builder.Property(r => r.Name)
                           .IsRequired()
                           .HasMaxLength(100)
                           .IsUnicode(false);
                     builder.Property(r => r.Description)
                            .IsRequired()
                            .HasMaxLength(400)
                            .IsUnicode(false);
                     builder.Property(r => r.AlarmDate)
                            .HasColumnType("DATETIME");
                     builder.Property(v => v.UserId)
                            .IsRequired();
                     builder.HasOne<User>() //ATUALIZADO 
                            .WithMany()
                            .HasForeignKey(v => v.UserId)
                            .HasConstraintName("FK_User_Remimder");
              }
       }
}