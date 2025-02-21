using GradesPrototype.Entities;
using System.Text.Json;

namespace GradesPrototype.Logic
{
    public static class Actions
    {
        public static List<Student> students = new List<Student>();

        public static void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();
            students.Add(new Student(name));
            Console.WriteLine("Студент добавлен.");
        }

        public static void RemoveStudent()
        {
            Console.Write("Введите индекс студента для удаления: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < students.Count)
            {
                students.RemoveAt(index);
                Console.WriteLine("Студент удален.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        public static void ShowAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов нет.");
                return;
            }

            Console.WriteLine("Список студентов:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i}. {students[i].Name}");
            }
        }

        public static void SerializeToJson()
        {
            Console.WriteLine("Введите путь для сохранения файла: ");
            try
            {   
                string filePath = Console.ReadLine();
                string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"\nОценки успешно сохранены в файл {filePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении оценок в файл: {ex.Message}");
            }
        }

        public static void ManageStudentGrades()
        {
            Console.Write("Введите индекс студента: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < students.Count)
            {
                Student student = students[index];
                Console.WriteLine($"Выбран студент: {student.Name}");

                while (true)
                {
                    Console.WriteLine($"Меню управления оценками студента {student.Name}:");
                    Console.WriteLine("1. Добавить оценку");
                    Console.WriteLine("2. Удалить оценку");
                    Console.WriteLine("3. Показать все оценки");
                    Console.WriteLine("4. Поиск оценок по предмету");
                    Console.WriteLine("5. Вернуться в главное меню");
                    Console.Write("Выберите опцию: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddGrade(ref student);
                            break;
                        case 2:
                            RemoveGrade(ref student);
                            break;
                        case 3:
                            student.ShowAllGrades();
                            break;
                        case 4:
                            SearchGradesBySubject(ref student);
                            break;
                        case 5:
                            students[index] = student;
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        public static void AddGrade(ref Student student)
        {
            Console.Write("Введите предмет -  ");
            Console.Write(string.Join(", ", Enum.GetNames(typeof(Subject))));
            Console.Write(": ");

            string subjectInput = Console.ReadLine();
            if (!Enum.TryParse(subjectInput, out Subject subject))
            {
                Console.WriteLine("Неверный предмет.");
                return;
            }

            Console.Write("Введите оценку: ");
            int score = int.Parse(Console.ReadLine());

            student.GradeAdded += (score) =>
            {
                Console.WriteLine($"Оценка {score} по предмету {subject} добавлена");
            };
            student.AddGrade(subject, score);
        }

        public static void RemoveGrade(ref Student student)
        {
            Console.Write("Введите индекс оценки для удаления: ");
            int index = int.Parse(Console.ReadLine());

            student.RemoveGrade(index);
        }

        public static void SearchGradesBySubject(ref Student student)
        {
            Console.Write("Введите предмет для поиска  -  ");
            Console.Write(string.Join(", ", Enum.GetNames(typeof(Subject))));
            Console.Write(": ");

            string subjectInput = Console.ReadLine();
            if (!Enum.TryParse(subjectInput, out Subject subject))
            {
                Console.WriteLine("Неверный предмет.");
                return;
            }

            var foundGrades = student.FindGradesBySubject(subject);
            if (foundGrades.Count == 0)
            {
                Console.WriteLine("Оценок по этому предмету нет.");
                return;
            }

            Console.WriteLine($"Оценки по предмету {subject}:");
            foreach (var grade in foundGrades)
            {
                Console.WriteLine(grade);
            }
        }
    }
}
