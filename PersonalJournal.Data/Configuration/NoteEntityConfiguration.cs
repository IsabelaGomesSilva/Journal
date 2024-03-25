using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalJournal.Domain.Models;

namespace Stories.Data.Configuration
{
       public class NoteEntityConfiguration : IEntityTypeConfiguration<Note>
       {
              public void Configure(EntityTypeBuilder<Note> builder)
              {
                     builder.ToTable("Note");

                     builder.Property(n => n.Id)
                            .ValueGeneratedOnAdd();
                     builder.Property(n => n.Name)
                           .IsRequired()
                           .HasMaxLength(100)
                           .IsUnicode(false);
                     builder.Property(n => n.Description)
                            .IsRequired()
                            .HasMaxLength(400)
                            .IsUnicode(false);
                     builder.Property(n => n.CurrentDate)
                            .HasColumnType("DATETIME");
                     builder.Property(n => n.UserId)
                            .IsRequired();
                     builder.HasOne<User>()  
                            .WithMany()
                            .HasForeignKey(n => n.UserId)
                            .HasConstraintName("FK_User_Note");
              }
       }
}