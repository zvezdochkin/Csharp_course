using static System.Runtime.InteropServices.JavaScript.JSType;

List<Grade> grades = new();

AddGrade(ref grades, Subject.Math, 4);
AddGrade(ref grades, Subject.Physics, 5);
AddGrade(ref grades, Subject.Chemistry, 3);

RemoveGrade(ref grades, Subject.Physics);

SearchBySubject(grades, Subject.Math);
SearchBySubject(grades, Subject.Physics);
SearchBySubject(grades, Subject.Chemistry);



static void AddGrade(ref List<Grade> grades, Subject subject, int score)
{
    grades.Add(new Grade(subject, score, DateTime.Now));
    Console.WriteLine($"Оценка {score} по предмету {subject} добавлена");
}

static void RemoveGrade(ref List<Grade> grades, Subject subject)
{
    var gradeToRemove = grades.Find(g => g.Subject == subject);
    if (gradeToRemove.Equals(default(Grade)))
    {
        Console.WriteLine($"Оценка по предмету {subject} не найдена");
    }
    else
    {
        grades.Remove(gradeToRemove);
        Console.WriteLine($"Оценка по предмету {subject} удалена");
    }
}

static void SearchBySubject(List<Grade> grades, Subject subject)
{
    bool found = false;

    foreach (var grade in grades)
    {
        if (grade.Subject == subject)
        {
            Console.WriteLine($"Предмет: {grade.Subject}, оценка: {grade.Score}, дата: {grade.Date.ToShortDateString()}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine($"По предмету {subject} нет оценки");
    }
}

public enum Subject
{
    Math,
    Physics,
    Chemistry
}

struct Grade
{
    public Subject Subject;
    public int Score;
    public DateTime Date;

    public Grade(Subject subject, int score, DateTime date)
    {
        Subject = subject;
        Score = score;
        Date = date;
    }
}
