using (ApplicationContext db = new ApplicationContext())
{
    Student Ivan = new Student { StudentId = 1, Name = "Ivan" };
    Student Alice = new Student { StudentId = 2, Name = "Alice" };

    db.Students.Add(Ivan);
    db.Students.Add(Alice);

    Subject math = new Subject { SubjectId = 1, SubjectName = "Math" };
    Subject phys = new Subject { SubjectId = 2, SubjectName = "Physics" };
    Subject chem = new Subject { SubjectId = 3, SubjectName = "Chemistry" };

    db.Subjects.Add(math);
    db.Subjects.Add(phys);
    db.Subjects.Add(chem);

    var grade1 = db.Grades.Add(new Grade { GradeId = 1, Student = Ivan, Subject = math, Score = 5, Date = new DateTime(2025, 02, 01) });
    var grade2 = db.Grades.Add(new Grade { GradeId = 2, Student = Ivan, Subject = phys, Score = 4, Date = new DateTime(2025, 02, 01) });
    var grade3 = db.Grades.Add(new Grade { GradeId = 3, Student = Alice, Subject = chem, Score = 4, Date = new DateTime(2025, 02, 03) });
    var grade4 = db.Grades.Add(new Grade { GradeId = 4, Student = Alice, Subject = math, Score = 3, Date = new DateTime(2025, 02, 03) });

    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    var students = db.Students.ToList();
    Console.WriteLine("\nСписок студентов:");
    foreach (Student s in students)
    {
        Console.WriteLine($"{s.StudentId}. {s.Name}");
    }

    var ivanGrades = db.Grades
                .Where(g => g.Student.Name == "Ivan")
                .Select(g => new
                {
                    SubjectName = g.Subject.SubjectName,
                    Score = g.Score,
                    Date = g.Date
                })
                .ToList();

    Console.WriteLine("\nОценки Ивана:");
    foreach (var grade in ivanGrades)
    {
        Console.WriteLine($"{grade.SubjectName}: {grade.Score} ({grade.Date.ToShortDateString()})");
    }

    var aliceGrades = db.Grades
                .Where(g => g.Student.Name == "Alice")
                .Select(g => new
                {
                    SubjectName = g.Subject.SubjectName,
                    Score = g.Score,
                    Date = g.Date
                })
                .ToList();

    Console.WriteLine("\nОценки Алисы:");
    foreach (var grade in aliceGrades)
    {
        Console.WriteLine($"{grade.SubjectName}: {grade.Score} ({grade.Date.ToShortDateString()})");
    }
}