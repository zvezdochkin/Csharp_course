using System.ComponentModel.DataAnnotations;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [Required]
    public string SubjectName { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}