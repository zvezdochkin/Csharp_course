using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Grade> Grades { get; set; }
}