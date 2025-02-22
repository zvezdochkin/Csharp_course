using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Grade
{
    [Key]
    public int GradeId { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }

    [ForeignKey("Subject")]
    public int SubjectID { get; set; } 

    [Required]
    public int Score { get; set; }
    public DateTime Date { get; set; }

    public virtual Student Student { get; set; }
    public virtual Subject Subject { get; set; }
}