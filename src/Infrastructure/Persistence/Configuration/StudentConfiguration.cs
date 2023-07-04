using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.SurName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.DateOfBirth).IsRequired();
        builder.Property(s => s.NationalId).IsRequired().HasMaxLength(50);
        builder.Property(s => s.StudentNumber).IsRequired().HasMaxLength(50);
    }
}