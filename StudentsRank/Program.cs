using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsRank
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Student>()
            {
                new Student{ FullName = "Rikko Marthy", GPA = 4.2f },
                new Student{ FullName = "James Bob", GPA = 4.5f },
                new Student{ FullName = "Leo Koma", GPA = 4.8f },
                new Student{ FullName = "Ben Bishop", GPA = 4.8f },
                new Student{ FullName = "Mike Myers", GPA = 4.0f }
            };

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:\n" +
                "1) Ввести данные студента\n" +
                "2) Отобразить список студентов\n" +
                "3) Отобразить лучшего студента по успеваемости\n" +
                "4) Отобразить худшего студента по успеваемости\n" +
                "5) Отобразить среднюю оценку группы\n" +
                "6) Выход из приложения");

                int choice = 0;
                bool success = int.TryParse(Console.ReadLine(), out choice);

                Console.Clear();

                if (choice >= 2 && choice <= 5)
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст. Пожалуйста введите сперва данные.");
                        Console.WriteLine("Чтобы продолжить нажмите Enter...");
                        Console.ReadLine();
                        continue;
                    }
                }

                if (success && (choice > 0 && choice <= 6))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите полное имя студента:");
                                string fullName = Console.ReadLine();

                                float gpa;
                                do
                                {
                                    Console.Clear();
                                    Console.Write("Введите среднюю оценку студента: ");
                                } while (!float.TryParse(Console.ReadLine(), out gpa));

                                list.Add(new Student { FullName = fullName, GPA = gpa });
                            }
                            break;
                        case 2:
                            {
                                if (list.Count > 0)
                                {
                                    list.Sort(new Student());

                                    foreach (Student student in list)
                                    {
                                        Console.WriteLine(student);
                                    }
                                }
                            }
                            break;
                        case 3:
                            {
                                float rank = list.Max(student => student.GPA);

                                List<Student> students = list.FindAll(s => s.GPA == rank);

                                if (students != null)
                                {
                                    ShowListOfStudents(students);
                                }
                            }
                            break;
                        case 4:
                            {
                                float rank = list.Min(student => student.GPA);

                                List<Student> students = list.FindAll(s => s.GPA == rank);

                                if (students != null)
                                {
                                    ShowListOfStudents(students);
                                }
                            }
                            break;
                        case 5:
                            {
                                float avgRank = list.Average(student => student.GPA);

                                ShowListOfStudents(list);
                                Console.WriteLine("\nСредняя оценка студентов: {0}", avgRank);
                            }
                            break;
                        case 6: Environment.Exit(0); break;
                        default:
                            break;
                    }
                    Console.WriteLine("Чтобы продолжить нажмите Enter...");
                    Console.ReadLine();
                }
            }
        }
        static void ShowListOfStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);

            }
        }
    }
}
/*1. Ввод данных студента (имя, средняя оценка)
2. Запись студентов в коллекцию
3. Отобразить только имя самого лучшего и худшего студента по успеваемости
4. Отобразить общую среднюю оценку по группе

Что должно быть в меню:
1-пункт: в цикле вводить данные студента и записывать их в коллекцию
2-пункт: отображение лучшего студента по успеваемости
3-пункт: отображение худшего студента по успеваемости
4-пункт: отображение средней оценки по группе
5-пункт: выход из приложения*/
