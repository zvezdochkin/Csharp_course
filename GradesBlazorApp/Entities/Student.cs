using System.ComponentModel.DataAnnotations;

namespace GradesBlazorApp.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        public string LastName { get; set; }

        public List<Grade> Grades { get; set; } = new();
    }
}
