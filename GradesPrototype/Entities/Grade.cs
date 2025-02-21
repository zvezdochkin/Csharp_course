namespace GradesPrototype.Entities
{
    public enum Subject
    {
        Math,
        Physics,
        Chemistry
    }

    public class Grade
    {
        public Subject Subject { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Grade(Subject subject, int score, DateTime date)
        {
            Subject = subject;
            Score = score;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Subject}: {Score} ({Date.ToShortDateString()})";
        }
    }
}