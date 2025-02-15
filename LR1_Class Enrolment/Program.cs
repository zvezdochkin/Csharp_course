using System;

class Program
{
    static string[] courses = new string[10];
    static string[,] students;
    static int[] maxStudents = new int[10];
    static int courseCount = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить курс");
            Console.WriteLine("2. Посмотреть курсы");
            Console.WriteLine("3. Удалить курс");
            Console.WriteLine("4. Записать студента на курс");
            Console.WriteLine("5. Показать список студентов на курсе");
            Console.WriteLine("6. Удалить студента из курса");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;
                case "2":
                    ViewCourses();
                    break;
                case "3":
                    RemoveCourse();
                    break;
                case "4":
                    EnrollStudent();
                    break;
                case "5":
                    ShowStudents();
                    break;
                case "6":
                    RemoveStudent();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова");
                    break;
            }
        }
    }

    static void AddCourse()
    {
        try
        {
            if (courseCount >= courses.Length)
            {
                Console.WriteLine("Достигнуто максимальное количество курсов");
                return;
            }

            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                Console.WriteLine("Название курса не может быть пустым");
                return;
            }

            for (int i = 0; i < courseCount; i++)
            {
                if (courses[i] == courseName)
                {
                    throw new InvalidOperationException("Курс уже существует");
                }
            }

            Console.Write("Введите максимальное количество студентов на курсе: ");
            if (!int.TryParse(Console.ReadLine(), out int maxStudentCount) || maxStudentCount <= 0)
            {
                throw new ArgumentException("Некорректное количество студентов");
            }

            courses[courseCount] = courseName;
            maxStudents[courseCount] = maxStudentCount;
            students = new string[courseCount + 1, maxStudentCount];
            courseCount++;
            Console.WriteLine($"Курс '{courseName}' добавлен с максимальным количеством студентов: {maxStudentCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении курса: {ex.Message}");
        }
    }

    static void ViewCourses()
    {
        Console.WriteLine("Список курсов:");
        for (int i = 0; i < courseCount; i++)
        {
            Console.WriteLine($"{courses[i]} (максимум {maxStudents[i]} студентов)");
        }
    }

    static void RemoveCourse()
    {
        Console.Write("Введите название курса для удаления: ");
        string courseName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(courseName))
        {
            Console.WriteLine("Название курса не может быть пустым");
            return;
        }

        int index = Array.IndexOf(courses, courseName);

        if (index == -1)
        {
            Console.WriteLine("Курс не найден");
            return;
        }

        for (int i = index; i < courseCount - 1; i++)
        {
            courses[i] = courses[i + 1];
            maxStudents[i] = maxStudents[i + 1];
        }

        courses[courseCount - 1] = null;
        maxStudents[courseCount - 1] = 0;
        courseCount--;
        Console.WriteLine($"Курс '{courseName}' удален");
    }

    static void EnrollStudent()
    {
        Console.Write("Введите название курса: ");
        string courseName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(courseName))
        {
            Console.WriteLine("Название курса не может быть пустым");
            return;
        }

        int courseIndex = Array.IndexOf(courses, courseName);

        if (courseIndex == -1)
        {
            Console.WriteLine("Курс не найден");
            return;
        }

        for (int i = 0; i < maxStudents[courseIndex]; i++)
        {
            if (students[courseIndex, i] == null)
            {
                Console.Write("Введите имя студента: ");
                string studentName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    Console.WriteLine("Имя студента не может быть пустым");
                    return;
                }

                students[courseIndex, i] = studentName;
                Console.WriteLine($"Студент '{studentName}' записан на курс '{courseName}'");
                return;
            }
        }

        Console.WriteLine("Нет свободных мест на курсе");
    }

    static void ShowStudents()
    {
        Console.Write("Введите название курса: ");
        string courseName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(courseName))
        {
            Console.WriteLine("Название курса не может быть пустым");
            return;
        }

        int courseIndex = Array.IndexOf(courses, courseName);

        if (courseIndex == -1)
        {
            Console.WriteLine("Курс не найден");
            return;
        }

        Console.WriteLine($"Список студентов на курсе '{courseName}':");
        for (int i = 0; i < maxStudents[courseIndex]; i++)
        {
            if (students[courseIndex, i] != null)
            {
                Console.WriteLine(students[courseIndex, i]);
            }
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Введите название курса: ");
        string courseName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(courseName))
        {
            Console.WriteLine("Название курса не может быть пустым");
            return;
        }

        int courseIndex = Array.IndexOf(courses, courseName);

        if (courseIndex == -1)
        {
            Console.WriteLine("Курс не найден");
            return;
        }

        Console.Write("Введите имя студента для удаления: ");
        string studentName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(studentName))
        {
            Console.WriteLine("Имя студента не может быть пустым");
            return;
        }

        for (int i = 0; i < maxStudents[courseIndex]; i++)
        {
            if (students[courseIndex, i] == studentName)
            {
                students[courseIndex, i] = null;
                Console.WriteLine($"Студент '{studentName}' удален из курса '{courseName}'");
                return;
            }
        }

        Console.WriteLine("Студент не найден на курсе");
    }
}
