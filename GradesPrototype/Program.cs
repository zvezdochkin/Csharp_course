using GradesPrototype.Entities;
using GradesPrototype.Logic;
using System.Text.Json.Nodes;

namespace GradesPrototype
{
    static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Показать всех студентов");
                Console.WriteLine("4. Управление оценками студента");
                Console.WriteLine("5. Сохранить оценки в JSON файл");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите опцию: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Actions.AddStudent();
                        break;
                    case 2:
                        Actions.RemoveStudent();
                        break;
                    case 3:
                        Actions.ShowAllStudents();
                        break;
                    case 4:
                        Actions.ManageStudentGrades();
                        break;
                    case 5:
                        Actions.SerializeToJson();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
