using System;
using System.Diagnostics;

namespace GradesPrototype.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(string name)
        {
            Name = name;
            Grades = new List<Grade>();
        }

        public delegate void GradeHandler(int newGrade);
        public event GradeHandler GradeAdded;

        public void OnGradeAdded(int score)
        {
            GradeAdded?.Invoke(score);
        }

        public void AddGrade(Subject subject, int score)
        {
            Grades.Add(new Grade(subject, score, DateTime.Now));
            // Console.WriteLine($"Оценка {score} по предмету {subject} добавлена");
            OnGradeAdded(score);
        }

        public void RemoveGrade(int index)
        {
            if (index >= 0 && index < Grades.Count)
            {
                Grades.RemoveAt(index);
                Console.WriteLine($"Оценка удалена");
            };
        }

        public List<Grade> FindGradesBySubject(Subject subject)
        {
            return Grades.FindAll(g => g.Subject == subject);
        }

        public void ShowAllGrades()
        {
            if (Grades.Count == 0)
            {
                Console.WriteLine("Оценок нет.");
                return;
            }

            Console.WriteLine($"Оценки студента {Name}:");
            for (int i = 0; i < Grades.Count; i++)
            {
                Console.WriteLine($"{i}. {Grades[i]}");
            }
        }
    }
}