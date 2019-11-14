using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;namespace ConsoleApp1
{
    public class Student
    {                           //Конструктор
        public string id;
        public string name;
        public DateTime dateOfBirth;            //DateTime - структура преднозначенная для работы с датой и временем
        public string instute;
        public string course;
        public string group;
        public float averagePoints;        public void Modify()            //Функция отвечающая за изменение данных студента
        {
            string input = "";

            while(input != "stop")
            {
                Console.Clear();
                Console.Write($"Студент: ID: {id} ФИО: {name} Дата рождения: {dateOfBirth.ToString("dd.MM.yyyy")} Институт: {instute} Курс: {course} Группа: {group} Средний балл: {averagePoints}\n\n");
                Console.WriteLine("\tКакую информацию хотите изменить?\n" +
                "\n 1. ФИО" +
                "\n 2. Дата рождения" +
                "\n 3. Институт" +
                "\n 4. Курс" +
                "\n 5. Группа" +
                "\n 6. Средний балл" +
                "\n 7. Выход из этого меню");

                Console.Write("\nВведите номер функции: ");
                input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        Console.Write("Введите новые данные: ");
                        name = Console.ReadLine();
                        Console.Write("Данные студента успешно обновлены\n");
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Введите новые данные: ");
                            dateOfBirth = DateTime.Parse(Console.ReadLine());
                            Console.Write("Данные студента успешно обновлены\n");
                        }
                        catch
                        {
                            Console.WriteLine("Не коректный ввод данных!");
                        }
                        break;
                    case "3":
                        Console.Write("Введите новые данные: ");
                        instute = Console.ReadLine();
                        Console.Write("Данные студента успешно обновлены\n");
                        break;
                    case "4":
                        Console.Write("Введите новые данные: ");
                        course = Console.ReadLine();
                        Console.Write("Данные студента успешно обновлены\n");
                        break;
                    case "5":
                        Console.Write("Введите новые данные: ");
                        group = Console.ReadLine();
                        Console.Write("Данные студента успешно обновлены\n");
                        break;
                    case "6":
                        try
                        {
                            Console.Write("Введите новые данные: ");
                            averagePoints = float.Parse(Console.ReadLine());
                            Console.Write("Данные студента успешно обновлены\n");
                        }
                        catch
                        {
                            Console.WriteLine("Не коректный ввод данных!");                            
                        }
                        break;
                    case "7":
                        return;
                    default:            //Защита от дурака
                        Console.WriteLine("Не коректный ввод данных!");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }        public string GetStudentInfo()          //Функция отвечает за формат данных о студенте
        {
            return $"{id} {name} {dateOfBirth.ToString("dd.MM.yyyy")} {instute} {course} {group} {averagePoints}";
        }        public void Print()         //Функция отвечает за вывод стедентов
        {
            Console.WriteLine($"ID: {id} ФИО: {name} Дата рождения: {dateOfBirth.ToString("dd.MM.yyyy")} Институт: {instute} Курс: {course} Группа: {group} Средний балл: {averagePoints}");
        }
    }    public class DB
    {
        public List<Student> students = new List<Student>();            //Создаем лист студентов

        public void Menu()          //Основное меню
        {
            string input = "";            while (input != "stop")
            {
                Console.Clear();
                Console.WriteLine("\tЗдравствуйте! Введите номер функции\n" +
                "\n1. Вывести список студентов" +
                "\n2. Добавление студентов" +
                "\n3. Сортировка по ФИО" +
                "\n4. Сортировка по дате" +
                "\n5. Обратная сортировка по ФИО" +
                "\n6. Обратная сортировка по дате" +
                "\n7. Поиск студентов по ФИО" +
                "\n8. Поиск студентов по дате рождения" +
                "\n9. Нахождение максимального среднего балла" +
                "\n10. Нахождение минимального среднего балла" +
                "\n11. Нахождение среднего балла" +
                "\n12. Нахождение суммы средних баллов" +
                "\n13. Сохранить данные в файл" +
                "\n14. Редактирование студентов" +
                "\n15. Выход из программы");

                Console.Write("\nВведите номер функции: ");
                input = Console.ReadLine();                switch (input)
                {
                    case "1":
                        Print(students);
                        break;
                    case "2":
                        Add(StudentsParseService.GetStudents());
                        break;
                    case "3":
                        Sort((x, y) => x.name.CompareTo(y.name));
                        break;
                    case "4":
                        Sort((x, y) => x.dateOfBirth.CompareTo(y.dateOfBirth));
                        break;
                    case "5":
                        Sort((x, y) => -x.name.CompareTo(y.name));
                        break;
                    case "6":
                        Sort((x, y) => -x.dateOfBirth.CompareTo(y.dateOfBirth));
                        break;
                    case "7":
                        Console.Write("Введите ФИО: ");
                        input = Console.ReadLine();
                        StudentsMenu(Search(x => x.name.Contains(input)));
                        break;
                    case "8":
                        Console.Write("Введите дату рождения: ");
                        input = Console.ReadLine();
                        try
                        {
                            StudentsMenu(Search(x => x.dateOfBirth == DateTime.Parse(input)));
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Дата введена в неверном формате");
                            break;
                        }
                    case "9":
                        float max = students.Max(y => y.averagePoints);
                        Print(Search(x => x.averagePoints == max));
                        break;
                    case "10":
                        float min = students.Min(y => y.averagePoints);
                        Print(Search(x => x.averagePoints == min));
                        break;
                    case "11":
                        Average();
                        break;
                    case "12":
                        Sum();
                        break;
                    case "13":
                        SaveToFile();
                        break;
                    case "14":
                        StudentsMenu(students);
                        break;
                    case "15":
                        return;
                    default:            //Защита от дурака
                        Console.WriteLine($"Упс! Функция \"{input}\" не найдена");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }
        public void StudentsMenu(List<Student> students)            //Функция вызывающая личное меню студента
        {
            Console.Clear();
            Print(students);

            if (students.Count == 0)
                return;

            string input = "";

            Console.Write("\nДля выхода дважды нажмите Enter. \nВведите ID студента :");
            input = Console.ReadLine();

            try
            {
                PodMenu(students.FirstOrDefault(x => x.id == input));
            }
            catch
            {
                Console.WriteLine("Не коректный ввод данных!");
            }
        }
        public void PodMenu(Student student)            //Личное меню студента
        {
            Console.Clear();
            string input = "";
            Int32 n;
            Console.WriteLine($"Что вы хотите сделать с {student.name}?" +
                "\n1. Изменить" +
                "\n2. Удалить");

            Console.Write("\nДля выхода дважды нажмите Enter. \nВведите номер функции: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    student.Modify();
                    return;
                case "2":
                    Delete(student);
                    return;
                case "stop":
                    break;
                default:
                    Console.WriteLine("Не коректный ввод данных!");
                    break;
            }
        }
        void Add(List<Student> students)            //Добавление студента(ов)
        {
            foreach (Student s in students)
                if (!this.students.Any(x => x.id == s.id))
                    this.students.Add(s);
                else
                    Console.WriteLine($"Студент с ID: {s.id} уже существует в базе и не может быть добавлен повторно");            if (students.Count != 0)
                Console.WriteLine("Информация о студентах успешно добавлена");
        }        void Modify(List<Student> students)         //Изменение студента(ов)
        {
            foreach (Student s in students)
            {
                int indexOfStudentToModify = this.students.FindIndex(x => x.id == s.id);                if (indexOfStudentToModify != -1)
                    this.students[indexOfStudentToModify] = s;
            }            if (students.Count != 0)
                Console.WriteLine("Информация о студентах успешно обновлена");
        }        void Delete(Student student)            //Удаление студента
        {
            this.students.RemoveAll(x => x.id == student.id);

            Console.WriteLine("Информация о студенте успешно удалена");
        }        void Sort(Comparison<Student> comparer)         //Сортировка
        {
            students.Sort(comparer);
            Console.WriteLine("Сортировка успешно завершена");
        }        List<Student> Search(Predicate<Student> predicate)          //Поиск
        {
            return students.FindAll(predicate);
        }        void Average()          //Средний балл
        {
            float average = 0;            foreach (Student s in students)
                average += s.averagePoints;            average = average / students.Count;
            Console.WriteLine($"Средний балл: {average}");
        }        void Sum()          //Сумма средних баллов
        {
            float sum = 0;            foreach (Student s in students)
                sum += s.averagePoints;            Console.WriteLine($"Сумма средних баллов: {sum}");
        }        void SaveToFile()           //Сохранение в файл
        {            File.WriteAllText("C:\\Users\\pavel\\Desktop\\test.txt", GetAllStudentsInfo());
            Console.WriteLine("Информация о студентах успешно сохранена");
        }        string GetAllStudentsInfo()         //Переводим в строки
        {
            string allInfo = "";            try
            {
                for (int i = 0; i < students.Count - 1; i++)
                    allInfo += students[i].GetStudentInfo() + "\r\n";
                allInfo += students[students.Count - 1].GetStudentInfo();
            }
            catch
            {
                return allInfo;
            }
            return allInfo;
        }        void Print(List<Student> students)          //Вывод
        {
            foreach (Student s in students)                s.Print();            if (students.Count == 0)
                Console.WriteLine("Список пуст!");
        }
    }    public static class StudentsParseService            //Сервис ввода студентов
    {
        public static List<Student> GetStudents()
        {
            Console.Clear();
            Console.WriteLine("\tКак вы хотите ввести данные?" +
                "\n1. С клавиатуры." +
                "\n2. Из файла");            List<Student> students = new List<Student>();            string input = Console.ReadLine();            switch (input)
            {
                case "1":
                    students = ParseStringsToStudents(KeyboardInput());
                    break;
                case "2":
                    students = ParseStringsToStudents(FileInput());
                    break;
                default:
                    Console.WriteLine("Неизвестная команда!");
                    break;
            }            return students;
        }        static string KeyboardInput()           //Ввод с клавиатуры
        {
            string input;            Console.WriteLine("Введите данные построчно в следующем формате: " +
                "\n\"ID Фамилия Имя (Отчество) ДД.ММ.ГГГГ Аббревиатура ВУЗа Курс Группа Средний балл\" или \"stop\" для окончания ввода");            string array = "";            input = Console.ReadLine();            while (input != "stop")
            {
                array += input;
                input = Console.ReadLine();                if (input != "stop")
                    array += "\r\n";
            }            return array;
        }        static string FileInput()           //Ввод с файла
        {            string text = "";            try
            {
                text = File.ReadAllText("C:\\Users\\pavel\\Desktop\\test.txt");
            }
            catch
            {
                Console.WriteLine("Файл не найден");
            }
            return text;
        }        static List<Student> ParseStringsToStudents(string toParse)         //Деление строк на элементы для работы с ними
        {
            List<Student> studentsParsed = new List<Student>();            foreach (string row in toParse.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                Student parsedStudent;
                if (TryParseStringsToStudent(row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), out parsedStudent))
                    studentsParsed.Add(parsedStudent);
            }            return studentsParsed;
        }        static bool TryParseStringsToStudent(string[] toParse, out Student student)         //Определитель элемента
        {
            student = new Student();            try
            {
                student.id = toParse[0];                int i;                for (i = 1; i < toParse.Length; i++)
                    if (!toParse[i].Contains("."))
                        student.name += toParse[i] + " ";
                    else
                        break;
                student.name = student.name.Remove(student.name.Length - 1);                student.dateOfBirth = DateTime.Parse(toParse[i]);
                student.instute = toParse[i + 1];
                student.course = toParse[i + 2];
                student.group = toParse[i + 3];
                student.averagePoints = float.Parse(toParse[i + 4]);
            }
            catch
            {
                Console.WriteLine("Некорректной ввод");
                return false;
            }
            return true;
        }
    }    class Program
    {
        static void Main(string[] args)
        {
            DB dataBase = new DB();
            dataBase.Menu();
        }
    }
}
// 14. пункт передвинуть в начало (2)
