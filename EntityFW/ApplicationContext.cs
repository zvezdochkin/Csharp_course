using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public ApplicationContext() => Database.EnsureCreated();

    string dbPath = "database.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Удаление файла БД для тестирования программы
        if (File.Exists(dbPath))
        {
            File.Delete(dbPath);
        }

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
