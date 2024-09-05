using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyApp.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(s => s.Image).IsRequired(true).HasMaxLength(1000);
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(50);

            builder.HasOne(s=>s.Group)
                .WithMany(s => s.Students)
                .HasForeignKey(s=>s.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
