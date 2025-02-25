using System.ComponentModel.DataAnnotations;

namespace GradesBlazorApp.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }

        [Required(ErrorMessage = "Оценка обязательна для заполнения")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        public int Score { get; set; }

        [Required(ErrorMessage = "Дата обязательна для заполнения")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Студент обязателен для заполнения")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required(ErrorMessage = "Предмет обязателен для заполнения")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
