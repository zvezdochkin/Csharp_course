using System.ComponentModel.DataAnnotations;

namespace GradesBlazorApp.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Название предмета обязательно для заполнения")]
        public string Name { get; set; }
    }
}
