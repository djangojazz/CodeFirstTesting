using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            this.ToTable("StudentInfo");

            this.HasKey<int>(s => s.StudentKey);

            this.Property(p => p.DateOfBirth)
                    .HasColumnName("DoB")
                    .HasColumnOrder(3)
                    .HasColumnType("datetime2");

            this.Property(p => p.StudentName)
                    .HasMaxLength(50);

            this.Property(p => p.StudentName)
                    .IsConcurrencyToken();

            this.HasMany<Course>(s => s.Courses)
               .WithMany(c => c.Students)
               .Map(cs =>
               {
                   cs.MapLeftKey("StudentId");
                   cs.MapRightKey("CourseId");
                   cs.ToTable("StudentCourse");
               });
        }
    }
}
