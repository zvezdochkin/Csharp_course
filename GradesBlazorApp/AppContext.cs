using Microsoft.EntityFrameworkCore;
using GradesBlazorApp.Entities;

namespace GradesBlazorApp.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Grade> Grades => Set<Grade>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "Иван", LastName = "Иванов" },
                new Student { StudentId = 2, FirstName = "Петр", LastName = "Петров" }
            );

            modelBuilder.Entity<Subject>().HasKey(s => s.SubjectId);

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Математика" },
                new Subject { SubjectId = 2, Name = "Информатика" }
            );

            modelBuilder.Entity<Grade>().HasKey(g => g.GradeId);

            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeId = 1, Score = 5, Date = DateTime.Now, StudentId = 1, SubjectId = 1 },
                new Grade { GradeId = 2, Score = 4, Date = DateTime.Now, StudentId = 1, SubjectId = 2 },
                new Grade { GradeId = 3, Score = 4, Date = DateTime.Now, StudentId = 2, SubjectId = 1 },
                new Grade { GradeId = 4, Score = 3, Date = DateTime.Now, StudentId = 2, SubjectId = 2 }
            );
        }
    }
}
