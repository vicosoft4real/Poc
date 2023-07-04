using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.SurName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.DateOfBirth).IsRequired();
        builder.Property(t => t.TeachNumber).IsRequired().HasMaxLength(50);
        builder.HasOne(t => t.Title).WithMany(t => t.Teachers).HasForeignKey(t => t.TitleId);
     
    }
}