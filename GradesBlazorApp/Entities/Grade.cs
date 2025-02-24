namespace GradesBlazorApp.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
